using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICallerTest
{
    class APIData
    {
        public string[] APIDataObj { get; set; }
    }
    class APIDataObject
    {
        public string id { get; set; }
        public string title { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string picture { get; set; }
    }
}

//{
//    "data": [
//        {
//        "id": "60d0fe4f5311236168a109ca",
//            "title": "ms",
//            "firstName": "Sara",
//            "lastName": "Andersen",
//            "picture": "https://randomuser.me/api/portraits/women/58.jpg"
//        },
//    ],
//    "total": 99,
//    "page": 0,
//    "limit": 5
//}