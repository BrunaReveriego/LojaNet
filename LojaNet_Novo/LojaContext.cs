using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LojaNet.Models;

namespace LojaNet.DAL
{
    public class LojaContext : DbContext
    {
        public LojaContext() : base(DbHelper.conexao)
        {


        }

        public DbSet<Produto> Produtos { get; set; }


    }
}
