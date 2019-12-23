using Microsoft.EntityFrameworkCore;
using ProjectURL.Domain.Interfaces;
using ProjectURL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectURL.Domain.Services
{
    public class UrlService:IUrlService
    {
       

        public const string urlDomain = "http://localhost";
        public const string urlPort = "8080";

    


        public UrlService()
        {
            
        }

        public Url ExecuteProcessShortURL(Url url)
        {

           

            if (url != null && IsURLValid(url))

            {

                var id = Guid.NewGuid();

                //guid is to long, the best is user a Identity
                url.shortURL = $"{urlDomain}:{urlPort}{id}";
                url.Id = id;
                return url;
               
             

            }
           
            else
            {
                throw new Exception("Url Invalida");

            }

        }


        public bool IsURLValid(Url url)
        {
            return DescriptionValid(url.description) && longURLValida(url.longURL);

        }

        public bool DescriptionValid(string descricao)
        {
            return !string.IsNullOrEmpty(descricao);

        }

        public bool shortURLValida(string shortURL)
        {
            return !string.IsNullOrEmpty(shortURL);

        }

        public bool longURLValida(string longURL)
        {
            return !string.IsNullOrEmpty(longURL);

        }


    }
}
