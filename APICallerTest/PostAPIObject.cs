using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICallerTest
{
    class CreatePost
    {
        public string text { get; set; }
        public string image { get; set; }
        public int likes { get; set; }
        public string[] tags { get; set; }
        public string owner { get; set; }
    }
}

//{
//"text": "Dogger oh ye",
//"image": "https://peteu.b-cdn.net/wp-content/uploads/2019/10/Pupreme-the-dog-face-red-dog.jpg",
//"likes": 999,
//"tags": ["animal","dog","shiba"],
//"owner": "60d0fe4f5311236168a109ca"
//}