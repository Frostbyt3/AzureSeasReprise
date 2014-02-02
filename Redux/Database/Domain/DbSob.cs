using Redux.Enum;

namespace Redux.Database.Domain
{
    public class DbSob
    {
        public virtual uint UID { get; set; }
        public virtual uint Mesh { get; set; }
        public virtual ulong MaxHp { get; set; }
        public virtual uint Flag { get; set; }
        public virtual ushort Map { get; set; }
        public virtual ushort X { get; set; }
        public virtual ushort Y { get; set; }
        public virtual string Name { get; set; }
        
    }
}

