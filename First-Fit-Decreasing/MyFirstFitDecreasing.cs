using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Fit_Decreasing
{
    public partial class MyFirstFitDecreasing : Component
    {
        public MyFirstFitDecreasing()
        {
            InitializeComponent();
        }

        public MyFirstFitDecreasing(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        //kutuya sığdırılacak olan sayıları tutmak için kullanılan int dizi property'si.
        public int[] numbers { get; set; }
        //kutuya sığdırılan sayıların kutu numarasını tutmak için kullanılan int dizi property'si.
        public int[] boxNumber { get; set; }
        //gerekli kutu sayısını tutmak için kullanılan property.
        public int requiredBox { get; set; }

        /// <summary>
        /// veri tipi string olan veriyi parametre olarak alan ve bu veriyi
        /// string değerinin aralarındaki virgülleri ve boşlukları silerek
        /// integer dizisine dönüştüren method.
        /// </summary>
        /// <param name="value">int diziye dönüştürmek için parametre olarak alınan string v veri.</param>
        /// <returns>int dizisine dönüştürülen dizi geri döndülür.</returns>
        [Description("Verilen string değerini integer diziye çeviren method."), Category("Appearance")]
        public int[] tointarray(string value)
        {
            //aralarında virgül olan değerleri parçalayarak str dizisine atar.
            string[] str = value.Split(',');
            int[] intarray = new int[str.Length];
            //string dizi tipini int dizi tipine dönüştürür.
            for (int i = 0; i < intarray.Length; ++i)
            {
                int j;
                string s = str[i];
                //string dizi tipinin int dizi tipine dönüşüp dönüşmediğini kontrol eder.
                //Dönüşüm için uygunsa dönüştürür.
                if (int.TryParse(s, out j))
                {
                    intarray[i] = j;
                }
            }
            return intarray;
        }
        /// <summary>
        /// FirstFitDecreasingAlgorithm önemli bir binpacking algoritmasıdır. Öğeleri büyükten küçüğe doğru sıralandıktan sonra
        /// ilk öğe ilk kutuya yerleştirilir. Ardından bu sırayla sonraki öğe her zaman ilk sığdığı kutuya yerleştirilir. 
        /// FirstFitDecreasingAlgorithm methodu verilen verileri verilen kutu boyutuna göre First Fit Decreasing
        /// algoritmasına göre kutulara yerleştirir.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="size"></param>
        /// <returns>Algoritma sonucu sayıların minimum seviyede ihtiyacı olan kutu sayısını geri döndürür.</returns>
        public int FirstFitDecreasingAlgorithm(string data, int size)
        {
            //datayı tointarray methoduyla parçalar ve her bir veriyi int olarak diziye atar.
            //Küçükten büyüğe sıralar ve ters çevirir.
            int[] numbersarray = tointarray(data);
            Array.Sort(numbersarray);
            Array.Reverse(numbersarray);


            boxNumber = new int[numbersarray.Length];
            for (int i = 0; i < boxNumber.Length; i++)
                boxNumber[i] = -1;

            requiredBox = 0;
            int[] binValues = new int[numbersarray.Length];
            for (int i = 0; i < binValues.Length; i++)
                binValues[i] = size;
            //verilen kutu boyutundan yerleştirilecek elemanı çıkarır ve yeterli yer varsa 
            //yerleştirerek hangi kutuya yerleştirdiğini boxNumber propertysinde saklar.
            for (int i = 0; i < numbersarray.Length; i++)
                for (int j = 0; j < binValues.Length; j++)
                {
                    if (binValues[j] - numbersarray[i] >= 0)
                    {
                        boxNumber[i] = j;
                        binValues[j] -= numbersarray[i];
                        break;
                    }
                }
            //İçerisine eleman yerleştirilmiş olan her bir kutunun sayısını bulur.
            for (int i = 0; i < binValues.Length; i++)
                if (binValues[i] != size)
                    requiredBox++;
            numbers = numbersarray;
            return requiredBox;
        }
    }
}
