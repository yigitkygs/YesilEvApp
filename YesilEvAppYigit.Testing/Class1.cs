using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEvAppYigit.DAL;
using YesilEvAppYigit.DTO;

namespace YesilEvAppYigit.Testing
{
    [TestClass]
    public class Class1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ProductDAL productDAL = new ProductDAL();
            bool result = productDAL.AddNewProduct(new ProductDTO()
            {
                BarcodeNo=Guid.NewGuid().ToString(),
                ProductName="Test Product",
                CreateDate=DateTime.Now,
                AddedBy=1
            });

            if (!result)
            {
                throw new Exception("Test sırasında bir hata oluştu");
            }
        }
    }
}
