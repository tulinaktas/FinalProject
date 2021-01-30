using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        InMemoryProductDal _productDal;
        public ProductManager(InMemoryProductDal productDal)
        {
            _productDal = productDal;
        }
        public List<Product> GetAll()
        {
            //İs kodlari
            //yetkisi var mi? 
            //kontroller yapıldıktan sonra return
            return _productDal.GetAll();

        }
    }
}
