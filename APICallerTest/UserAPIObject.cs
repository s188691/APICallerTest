using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICallerTest
{
    class UsersMainData
    {
        public UsersDetailsData[] data { get; set; }
        public int total { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
    }
    class UsersDetailsData
    {
        public string id { get; set; }
        public string title { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string picture { get; set; }
    }
}


// Data presentation example
//{
//    "data": [
//        {
//        "id": "60d0fe4f5311236168a109ca",
//        "title": "ms",
//        "firstName": "Sara",
//        "lastName": "Andersen",
//        "picture": "https://randomuser.me/api/portraits/women/58.jpg"
//        },
//    ],
//    "total": 99,
//    "page": 0,
//    "limit": 5
//}