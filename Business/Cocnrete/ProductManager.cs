using Business.Abstract;
using Business.Contants;
using Business.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.ProductDtos;
using System;
using System.Collections.Generic;


namespace Business.Cocnrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal= productDal;
        }
        
        public IResult Add(ProductAddDto product)
        {
            var xx = new Product();
            xx.ProductName = product.ProductName;
            xx.UnitPrice= product.UnitPrice;
            xx.CategoryId   = product.CategoryId;
            _productDal.Add(xx);
            
            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.Success);
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.GetById(x=> x.Id ==id));
        }

        public IResult Update(Product product)
        {
           _productDal.Update(product);
            return new SuccessResult(Messages.Success);
        }
    }
}
