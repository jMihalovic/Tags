using System;
using System.Collections.Generic;
using System.Text;

namespace Tags
{
    class Tags
    {

        public static List<Tags> SeznamTagu = new List<Tags>();

        public Tags(string jm)
        {

            Jmeno = jm;
            bool flag = false;
            foreach (Tags x in SeznamTagu)
            {

                if (x.Jmeno == Jmeno) { flag = true;break; }

            }
            if (flag == false) SeznamTagu.Add(this);

        }

        private string _Jmeno;
        public string Jmeno
        {

            get 
            {

                return _Jmeno;
            
            }
            private set
            {

                _Jmeno = value;
            
            }
        
        }

        public static string Formatovani(string text, string tag)
        {
            string result = "";
            //Capital, Brackets, Reverse, Warning, Separated
            switch (tag) 
            {

                default:
                    break;

                case "capital":
                    result = text.ToUpper();
                    break;

                case "brackets":
                    result = "(" + text + ")";
                    break;

                case "reverse":
                    while(text != "")
                    {

                        result = result + text.Substring(text.Length-1);
                        text = text.Substring(0, text.Length - 1);

                    }
                    break;

                case "warning":
                    result = "!!! " + text.ToUpper() + " !!!";
                    break;

                case "separated":
                    foreach(char x in text)
                    {

                        result = result + " " + x;
                    
                    }
                    result.Trim();
                    break;
                    
            }
            return result;

        }

    }
}
