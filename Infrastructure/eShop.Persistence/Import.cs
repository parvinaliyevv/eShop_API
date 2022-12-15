global using System.Linq.Expressions;

global using eShop.Domain.Entities.Concrete;
global using eShop.Domain.Entities.Abstract;
global using eShop.Application.Repositories;
global using eShop.Persistence.Data.Contexts;
global using eShop.Persistence.Data.Configurations;
global using eShop.Persistence.Repositories.OrderRepository;
global using eShop.Application.Repositories.OrderRepository;
global using eShop.Application.Repositories.ProductRepository;
global using eShop.Persistence.Repositories.ProductRepository;
global using eShop.Application.Repositories.CustomerRepository;
global using eShop.Persistence.Repositories.CustomerRepository;
global using eShop.Application.Repositories.CategoryRepository;
global using eShop.Persistence.Repositories.CategoryRepository;

global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
