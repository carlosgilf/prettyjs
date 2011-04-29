using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Collections;
using Sloppycode;

namespace Common
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Hashtable ht = new Hashtable();
        private void button1_Click(object sender, EventArgs e)
        {
            
            var gen=new AlphaNumericPasswordGenerator();

            var pgen = new PronounceablePasswordGenerator();
            //var pwds=pgen.Generate(10000, 8);

            //for (var j=0;j<pwds.Count;j++)
            //{
            //    try
            //    {
            //        ht.Add(pwds[j], 1);
            //    }
            //    catch (System.Exception ex)
            //    {
            //        MessageBox.Show(j.ToString());
            //        break;
            //    }
            //}

            long i = 0;
            while (true)
            {
                //var g = Guid.NewGuid().ToString().Replace("-", "");
                //var guid = g.Substring(g.Length - 6, 6);
                try
                {
                    //ht.Add(guid, 1);
                    //ht.Add(GetUniqueKey(), 1);


                    ht.Add(Guid.NewGuid(),1);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(i.ToString());
                    break;
                }

                i++;
                if (i == 100000000)
                {
                    break;
                }
            }
            
           
        }

        public static string GetRandCode()
        {
            char[] source = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 
                                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U','V','W','X','Y','Z'};
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < 8; i++)
            {
                sb.Append(source[rand.Next(0, source.Length - 1)]);
            }
            return sb.ToString();
        }

        private string GetUniqueKey()
        {
            int maxSize = 6;
            //int minSize = 7;
            char[] chars = new char[62];
            string a;
            a = "abcdefghijklmnopqrstuvwxyz1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length - 1)]);
            }
            return result.ToString();
        }


        static Random r = new Random();
        public static string getRandomPassword(int letters, int getallen)
        {
            //int letters = 8;
            //int getallen = 5;

            char[] letterdeel = new char[letters];
            int minGetal = (int)Math.Pow(10, getallen - 1);
            int maxGetal = (int)Math.Pow(10, getallen);

            string password;
            
            int test = (int)(DateTime.Now.Ticks);
            for (int i = 0; i < letters; i++)
            {
                //r = new Random((int)(DateTime.Now.Ticks) + i);
                bool capital = r.Next(2) == 0 ? true : false;
                if (capital)
                {
                    letterdeel[i] = (char)r.Next(65, 91);
                }
                else
                {
                    letterdeel[i] = (char)r.Next(97, 123);
                }
            }

            password = new string(letterdeel);
            password += r.Next(minGetal, maxGetal);

            return password;
        }


        private string RandomString(int size, bool lowerCase)
        {

            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();

            return builder.ToString();
        }

    }
}
