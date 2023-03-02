using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


    public class MessageDigest
    {
        public string Text { get; set; }
        public string Algorithm { get; set; }

        public MessageDigest(string text,
            string hashAlgorithm)
        {
            this.Text = text;
            this.Algorithm = hashAlgorithm;
        }

        public byte[] Digest()
        {
            if (string.IsNullOrEmpty(this.Text))
                throw new ApplicationException("Message is empty");
            else
            {
                byte[] bytes = Encoding.Default.GetBytes(this.Text);
                HashAlgorithm hash = HashAlgorithm.Create(this.Algorithm);
                byte[] hashcode = hash.ComputeHash(bytes);
                return hashcode;
            }
        }
    }
