using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //business codes --> gecerliyse ekle degilse ekleme gibi

            if (product.ProductName.Length<2)
            {
                //magic string 
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            //return new Result(true, "Urun eklendi");
            //return new Result(true);

            return new SuccessResult(Messages.ProductAdded);
            //return new SuccessResult();
        }

        public IDataResult<List<Product>> GetAll()
        {
            //İs kodlari
            //yetkisi var mi? 
            //kontroller yapıldıktan sonra return
            //return new DataResult<List<Product>>
            // (_productDal.GetAll(),true,"Urunler listelendi");
            //if (DateTime.Now.Hour == 22) // sistemde 22den sonra listelenmesini istemiyoruz
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}

            return new SuccessDataResult<List<Product>>
             (_productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>
                (_productDal.GetAll(p => p.CategoryId == categoryId));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>
                (_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll
                (p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>
                (_productDal.GetProductDetails());
        }
    }
}
