using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationApp
{
    internal class FileObject
    {
        public string Path { get; set; } = string.Empty;  // 空文字（""）を入れる
        public string RenamePath { get; set; } = string.Empty;
    }
}
