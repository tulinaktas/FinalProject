using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //business codes --> gecerliyse ekle degilse ekleme gibi

            //validation(nesnenin yapısal olarak uygun olup olmadıgını kontrol eder)
            //business ve validation kodlarını ayrı ayrı yapmalıyız

            //if (product.UnitPrice <= 0)
            //{
            //    return new ErrorResult(Messages.UnitPriceInvalid);
            //}

            //if (product.ProductName.Length<2) // validation
            //{
            //    //magic string 
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}

            //var context = new ValidationContext<Product>(product);
            //ProductValidator productValidator = new ProductValidator();
            //var result = productValidator.Validate(context);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}
            //ValidationTool.Validate(new ProductValidator(), product);


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
            if (DateTime.Now.Hour == 1) // sistemde 22de listelenmesini istemiyoruz
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

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
