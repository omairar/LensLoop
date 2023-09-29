using DAL.UnitsOfWork;
using DAL.UnitsOfWork.Interfaces;

namespace DAL
{
    

    public class LLDB : ILLDB
    {
        LLDBContext context;
        public LLDB(LLDBContext _context)
        {
            context = _context;
        }

        IPostDB _postDb;

        public IPostDB postDB
        {
            get
            {
                if (_postDb == null)
                {
                    _postDb = new PostDB(context);
                }
                return _postDb;
            }
        }

    }
}