using ApiToConsume.Model;

namespace ApiToConsume.Services
{
    public interface IDemoServices
    {
        public bool createData(DemoModel model);
        public List<DemoModel> get();
        public DemoModel getById(DemoModel demo);
        public bool edit(DemoModel demo);
        public bool delete(DemoModel demo);
    }
}
