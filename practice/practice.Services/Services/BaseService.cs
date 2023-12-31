﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using practice.Model;
using practice.Services.Data;
using practice.Services.Helpers;
using practice.Services.SearchObjects;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Services
{
    public class BaseService<T,TDb,TS,TInsert,TUpdate> : IBService<T,TS,TInsert,TUpdate> where TDb : class where T:class where TS : Pagination where TInsert : class where TUpdate : class
    {
       protected readonly PracticeContext _context;
       protected readonly IMapper _mapper;
        public BaseService(PracticeContext context, IMapper mapper)
        {
            _context = context;
            _mapper=mapper;
        }

       

        public async Task<IList<T>> GetAll(TS? search = null)
        {
           string token = Generator.GenerateToken(10);
            var query = _context.Set<TDb>().AsQueryable();

            query = AddInclude(query);

            query = AddFilter(query, search);
            
            if(search?.PageSize > 0 && search?.PageNumber > 0)
            {
                query = query.Take(search.PageSize).Skip((search.PageNumber - 1) * search.PageSize);
            }

            

            var lista = await query.ToListAsync();

            
            

            return _mapper.Map<IList<T>>(lista);
        }

        public virtual IQueryable<TDb> AddInclude(IQueryable<TDb> query)
        {
            return query;
        }

        public virtual IQueryable<TDb> AddFilter(IQueryable<TDb> query, TS? search = null)
        {
            return query;
        }

        public async Task<T> GetById(int id)
        {
            var find = await _context.Set<TDb>().FindAsync(id);
            if(find == null)
            {
                throw new UserException("No object under that id");
            }
            return _mapper.Map<T>(find);
        }

        public virtual async Task<T> Insert(TInsert req)
        {
            var entity = _mapper.Map<TDb>(req);
            await _context.Set<TDb>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<T>(entity);
        }

        public virtual async Task<bool> Delete(int id)
        {
            var find = await _context.Set<TDb>().FindAsync(id);
            if (find == null)
                return false;
            _context.Remove(find);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<T> Update(int id,TUpdate req)
        {
            var entity = await _context.Set<TDb>().FindAsync(id);
            _mapper.Map(req, entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<T>(entity);
        }
    }
}
