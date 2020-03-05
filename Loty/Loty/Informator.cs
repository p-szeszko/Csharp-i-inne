using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;


namespace Loty
{
    class Informator
    {
        string[] wyloty = { "08:00", "09:43", "11:19", "12:47", "14:00", "15:45", "19:00", "21:45", "22:50", "23:45" };
        string[] przyloty = {"10:16","11:52","13:31","15:00","16:08","17:55","21:27","13:58","01:55","02:50" };

        public Informator()
        {

        }
      

        public TimeSpan[] znajdzLot(TimeSpan czas)
        {
            
            TimeSpan[] wynik= new TimeSpan[3];
            int i = 0;
            Boolean znaleziono = false;
            if (czas > TimeSpan.ParseExact("23:45", "h\\:mm", null, System.Globalization.TimeSpanStyles.None))
            {
                wynik[0] = TimeSpan.ParseExact(wyloty[0], "h\\:mm", null, System.Globalization.TimeSpanStyles.None);
                wynik[1] = TimeSpan.ParseExact(przyloty[0], "h\\:mm", null, System.Globalization.TimeSpanStyles.None);
                return wynik;
            }
            else {
                while (!znaleziono && i < wyloty.Length)
                {
                    if (czas <= TimeSpan.ParseExact(wyloty[i], "h\\:mm", null, System.Globalization.TimeSpanStyles.None))
                    {
                        wynik[0] = TimeSpan.ParseExact(wyloty[i], "h\\:mm", null, System.Globalization.TimeSpanStyles.None);
                        wynik[1] = TimeSpan.ParseExact(przyloty[i], "h\\:mm", null, System.Globalization.TimeSpanStyles.None);
                       

                            znaleziono = true;
                    }
                    i++;
                }
            }
            return wynik;
        }

    }
}

