using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDiscountLibrary

{
    public class EmployeeDiscount
    {
        public int YearsEmployed { get; set; }
        public decimal SumOfPastPurchase { get; set; }
        public decimal SumOfCurrentPurchase { get; set; }

        public EmployeeDiscount(int YearsEmployed, decimal SumOfPastPurchase, decimal SumOfCurrentPurchase)
        {
            this.YearsEmployed = YearsEmployed;
            this.SumOfPastPurchase = SumOfPastPurchase;
            this.SumOfCurrentPurchase = SumOfCurrentPurchase;
        }
        public static bool isValid(float UserInput)
        {
            if (UserInput < 0.0)
            {
                Console.WriteLine("Invalid");
                return false;

            }
            else
            {
                return true;
            }
        }
        public static float GetDiscount(int YearsEmployed, bool Option)
        {
            float[] HourlyDiscounts = new float[] { 0.10F, 0.14F, 0.20F, 0.25F, 0.30F };
            float[] ManagementDiscounts = new float[] { 0.20F, 0.24F, 0.30F, 0.35F, 0.40F };

            float Discount = 0.0F;
            if (Option == true)
            {
                if (YearsEmployed <= 3)
                {
                    Discount = ManagementDiscounts[0];
                }
                else if ((YearsEmployed <= 6))
                {
                    Discount = ManagementDiscounts[1];

                }
                else if ((YearsEmployed <= 10))
                {
                    Discount = ManagementDiscounts[2];

                }
                else if ((YearsEmployed <= 15))
                {
                    Discount = ManagementDiscounts[3];

                }
                else if (YearsEmployed > 15)
                {
                    Discount = ManagementDiscounts[4];
                }
            }
            else if (Option == false)
            {
                if (YearsEmployed <= 3)
                {
                    Discount = HourlyDiscounts[0];
                }
                else if ((YearsEmployed <= 6))
                {
                    Discount = HourlyDiscounts[1];

                }
                else if ((YearsEmployed <= 10))
                {
                    Discount = HourlyDiscounts[2];

                }
                else if ((YearsEmployed <= 15))
                {
                    Discount = HourlyDiscounts[3];

                }
                else if (YearsEmployed > 15)
                {
                    Discount = HourlyDiscounts[4];
                }
            }
            return Discount;
        }

        public static decimal GetYTDdiscount(decimal SumOfPastPurchase, float discount)
        {
            decimal YTDdiscount = SumOfPastPurchase * (decimal)discount;
            return YTDdiscount;
        }
        public static decimal getCurrentDiscount(decimal SumOfCurrentPurchase, float discount)
        {
            decimal CurrentDiscount = SumOfCurrentPurchase * (decimal)discount;
            return CurrentDiscount;
        }
        public static decimal getSumOfAllDiscounts(decimal YTDdiscount, decimal CurrentDiscount)
        {
            decimal SumOfAllDiscounts = (YTDdiscount + CurrentDiscount);
            return SumOfAllDiscounts;

        }
        public static decimal getCurrentPurchaseDiscount(decimal SumOfAllDiscounts, decimal CurrentDiscount, decimal YTDdiscount)
        {
            decimal TodaysDiscount = 0.0M;
            decimal PlaceHolder;
          
            if (SumOfAllDiscounts < 200)
            {
                TodaysDiscount = CurrentDiscount; 
            }
            else if (YTDdiscount > 200)
            {
                TodaysDiscount = CurrentDiscount * 0.0M;
            }
            else if (SumOfAllDiscounts > 200)
            {
                PlaceHolder = SumOfAllDiscounts - 200;
                TodaysDiscount = CurrentDiscount - PlaceHolder;
            }
          
            return TodaysDiscount;
        }

        public static decimal getTodaysPurchasePrice(decimal TodaysPurchase, decimal TodaysDiscount)
        {
            decimal TodaysPurchasePrice = TodaysPurchase - TodaysDiscount;
            return TodaysPurchasePrice;
        }

    }
}
