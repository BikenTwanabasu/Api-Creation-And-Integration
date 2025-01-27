using ApiToConsume.Model;
using System.Data.SqlClient;
using System.Reflection;

namespace ApiToConsume.Services
{
    public class DemoServices:IDemoServices
    {
        public readonly IConfiguration _configuration;

        public DemoServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string ConnectionString()
        {
            string Constr = _configuration.GetConnectionString("Dbss");
            return Constr;
        }

        public bool createData(DemoModel model)
        {
            int i = 0;
            using (SqlConnection con = new SqlConnection(ConnectionString())) {

                con.Open();
                SqlCommand cmd = new SqlCommand("spdemoProc", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flag", "Create");
                cmd.Parameters.AddWithValue("@Address", model.Address);
                cmd.Parameters.AddWithValue("@Age", model.Age);
                cmd.Parameters.AddWithValue("@Name", model.Name);

                i=cmd.ExecuteNonQuery();

                return i> 0;    
            }
            


        }
        public List<DemoModel> get()
        {
            List<DemoModel> modelList = new List<DemoModel>();
            using (SqlConnection con = new SqlConnection(ConnectionString()))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("spdemoProc", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flag", "View");
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    DemoModel demo =new DemoModel();
                    demo.Id = rdr["Id"].ToString();
                    demo.Name = rdr["Name"].ToString();
                    demo.Address = rdr["Address"].ToString();
                    demo.Age = rdr["Age"].ToString();
                    modelList.Add(demo);
                }
                return modelList;


            }
               

        }
        public DemoModel getById(DemoModel demo)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString()))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("spdemoProc", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flag", "ViewById");
                cmd.Parameters.AddWithValue("@Id", demo.Id);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    demo.Id = rdr["Id"].ToString();
                    demo.Name = rdr["Name"].ToString();
                    demo.Address = rdr["Address"].ToString();
                    demo.Age = rdr["Age"].ToString();
                   
                }
                return demo;


            }


        }
        public bool edit(DemoModel demo)
        {
            var i = 0;
            using (SqlConnection con = new SqlConnection(ConnectionString()))
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("spdemoProc", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@flag", "Edit");
                cmd.Parameters.AddWithValue("@Id", demo.Id);
                cmd.Parameters.AddWithValue("@Address", demo.Address);
                cmd.Parameters.AddWithValue("@Age", demo.Age);
                cmd.Parameters.AddWithValue("@Name", demo.Name);
                i = cmd.ExecuteNonQuery();
                return i > 0;


            }


        }

        public bool delete(DemoModel demo)
        {
            
                var i = 0;
                using (SqlConnection con = new SqlConnection(ConnectionString()))
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("spdemoProc", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@flag", "Delete");
                    cmd.Parameters.AddWithValue("@Id", demo.Id);
                    i = cmd.ExecuteNonQuery();
                    return i > 0;


                }
        }
    }
}
