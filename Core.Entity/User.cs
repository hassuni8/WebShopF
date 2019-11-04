using System;

namespace Core.Entity
{
    public class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        
        public byte[] PassWordHash{ get; set; }
        
        public byte[]  PaswordSalt { get; set; }
        
        public bool IsAtmin { get; set; }
        
    }
}