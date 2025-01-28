using ApiToConsume.Model;

namespace ApiToConsume.Services
{
    public interface IDemoServices
    {
        public bool createData(DemoModel model);
        public List<DemoModel> get();
        public DemoModel getById(int Id);
        public bool edit(int Id);
        public bool delete(DemoModel demo);
    }
}
