using ProjectURL.Data.Context;
using ProjectURL.Domain.Interfaces;
using ProjectURL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectURL.Data.Repository
{
    public class UrlRepository:Repository<Url>,IUrlRepository
    {

        protected readonly ProjectURLContext _Db;

        public UrlRepository(ProjectURLContext _Db) :base(_Db)
        {

        }
    }
}
