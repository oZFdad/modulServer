using System;

namespace Helper
{
    public class Token
    {
        public Guid KeyToken { get; }
        public DateTime LifeTime { get; }
        public int UserID { get; }

        public Token()
        {
            KeyToken = Guid.NewGuid();
        }
    }
}