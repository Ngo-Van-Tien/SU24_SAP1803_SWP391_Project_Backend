using Infrastructure.IRepositories;
using SWP.Infrastrcuture;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        public ImageRepository(SWPDbContext context) : base(context)
        {
        }

        public async Task AddImage(Image image)
        {
            await _context.Set<Image>().AddAsync(image);
            await _context.SaveChangesAsync();
        }
    }
}
