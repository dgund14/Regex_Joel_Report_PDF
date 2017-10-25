using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regex_Joel_Report_PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            string input =
                @"START
REPORT-ABCDFG11 ;ljkdfklahdfkahdfkhadlfhalfdh
Aldfaldfaljflajdflajdflajfdladfadfahfaklhfdakladsfa
Adlfhadlfjaldfjaldjflajfdlajflajfdlajfdlajdflajfdlajfas
REPORT-dle32343  alsdfkhalkdfjladjsflajdflkajdflk
Akdjfhakjdhfaksdhfladfjhladfjlakjdflajksdflajkdsflk
Adhfakdhfkahdfkadhjfkadhjfakhsjdfkadhsfkahdfk
REPORT-OIUDH12 alsdkfladjflasjdflajdflajflajdflajl
Alkdflajdflajdflajdflajdflajsdflasjdflajdflasdjflajdfka
Ladfjaljfdaljflajsdflajdfaljfdldajflajfdladjfladjfkaldjs
END";
            string pattern = @"REPORT-(?<Name>.*?) (?<Data>.*?)(?=REPORT|END)";
            MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
            Debug.Print("Found {0} matches.",matches.Count);
            //loop through the matches
            foreach (Match m in matches)
            {
                //loop through each group in each match
                for (int i = 0; i < m.Groups.Count; i++)
                {
                    Debug.Print("m.Groups[{0}]: {1}", i, m.Groups[i].Value);
                }

                //here is accessing your data by the named capture group
                Debug.Print("m.Groups[Name]: {0}", m.Groups["Name"].Value);
                Debug.Print("m.Groups[Data]: {0}", m.Groups["Data"].Value);
            }
        }
    }
}
