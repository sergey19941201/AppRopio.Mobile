using System;
using System.Collections.Generic;
using System.Globalization;
using Android.Graphics;
using Android.Text;
using Android.Text.Style;
using MvvmCross.Platform.Converters;

namespace AppRopio.ECommerce.Basket.Droid.ValueConverters
{
    public class BasketMessageBoldValueConverter : MvxValueConverter<string, SpannableString>
    {
        protected override SpannableString Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            if (String.IsNullOrEmpty(value))
                return null;
            var discountStartIndexes = AllIndexesOf(value.ToLower(), "скидка");
            SpannableString spannable = new SpannableString(value);

            for (int i = 0; i < discountStartIndexes.Count; i++)
            {
                var currentIndex = discountStartIndexes[i];
                for (int y = currentIndex; y < value.Length; y++)
                {
                    if (value[y] == '%')
                    {
                        spannable.SetSpan(new StyleSpan(TypefaceStyle.Bold), currentIndex, y, 0);
                        break;
                    }
                }
            }
            return spannable;
        }

        List<int> AllIndexesOf(string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }
    }
}
