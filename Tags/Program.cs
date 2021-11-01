using System;
using System.IO;

namespace Tags
{
    class Program
    {
        static void Main(string[] args)
        {
            Tags Capital = new Tags("capital");
            Tags Brackets = new Tags("brackets");
            Tags Reverse = new Tags("reverse");
            Tags Warning = new Tags("warning");
            Tags Separated = new Tags("separated");
            StreamReader sr = new StreamReader("text.txt");
            string neupravenyText = sr.ReadToEnd();
            string upravenyText = "";
            string tag = "";
            string formatovanyText = "";
            int indexPrvniZavorky = -1;
            int indexDruheZavorky = -1;
            int indexTretiZavorky = -1;
            int indexCtvrteZavorky = -1;
            bool flag1 = false;
            bool flag2 = false;

            while (neupravenyText != "")
            {
                try
                {
                    indexPrvniZavorky = neupravenyText.IndexOf("<");
                    indexDruheZavorky = neupravenyText.IndexOf(">", indexPrvniZavorky);
                    indexTretiZavorky = neupravenyText.IndexOf("<", indexDruheZavorky);
                    indexCtvrteZavorky = neupravenyText.IndexOf(">", indexTretiZavorky);
                }

                catch 
                {
                

                
                }

                if (indexPrvniZavorky != -1 && indexDruheZavorky != -1 && indexTretiZavorky != -1 && indexCtvrteZavorky != -1)
                {

                    tag = neupravenyText.Substring(indexPrvniZavorky + 1, indexDruheZavorky - indexPrvniZavorky - 1);

                    foreach (Tags x in Tags.SeznamTagu)
                    {

                        if (x.Jmeno == tag)
                        {
                            flag1 = true;
                            break;
                        }
                        else flag1 = false;

                    }

                    foreach (Tags x in Tags.SeznamTagu)
                    {

                        if ("/" + x.Jmeno == "/" + tag)
                        {
                            flag2 = true;
                            break;
                        }
                        else flag2 = false;

                    }

                    if (flag1 == true && flag2 == true)
                    {

                        upravenyText = upravenyText + neupravenyText.Substring(0, indexPrvniZavorky);
                        formatovanyText = Tags.Formatovani(neupravenyText.Substring(indexDruheZavorky + 1, indexTretiZavorky - indexDruheZavorky - 1), tag);
                        neupravenyText = neupravenyText.Substring(indexCtvrteZavorky + 1);
                        upravenyText = upravenyText + formatovanyText;

                    }

                    else
                    {

                        upravenyText = upravenyText + neupravenyText.Substring(0, indexPrvniZavorky+1);
                        neupravenyText = neupravenyText.Substring(indexPrvniZavorky+1);

                    }
                }

                else 
                {

                    upravenyText = upravenyText + neupravenyText;
                    neupravenyText = "";

                }

            }
            File.WriteAllTextAsync("Upravený Text.txt", upravenyText);
            Console.WriteLine(upravenyText);
            Console.ReadLine();
        }
    }
}
