using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using back_end.DatabaseContext;
using back_end.Domain.Entities;
using back_end.DTO;
using back_end.ServiceContracts.Repository;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using System.Security.Claims;

namespace back_end.Services.Repository
{
    public class NewConnectionFormRepository : INewConnectionFormRepository
    {
        private readonly ApplicationDbContext _context;
        private static readonly Random random = new Random();
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NewConnectionFormRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<NewConnectionForm>> GetAllNewConnectionFormsAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Find all new connection forms associated with the user ID
            var entities = await _context.NewConnectionForms
                .Where(form => form.UserId == userId)
                .ToListAsync();

            return entities;
        }

        public async Task<NewConnectionFormDTO> GetNewConnectionFormByIdAsync(int id)
        {
            if (_context.NewConnectionForms == null)
            {
                return null;
            }
            var entity = await _context.NewConnectionForms.FindAsync(id);

            if (entity == null)
            {
                return null;
            }

            var dto = new NewConnectionFormDTO
            {
                ConnectionNo = entity.ConnectionNo,
                Name = entity.Name,
                Email = entity.Email,
                Dob = entity.Dob,
                MaritalStatus = entity.MaritalStatus,
                MobileNo = entity.MobileNo,
                Gender = entity.Gender,
                Nationality = entity.Nationality,
                Address = entity.Address,
                Document = entity.AddressProof,
                RationCardNo = entity.RationCardNo,
                Related = entity.Related,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                RelatedAddress = entity.RelatedAddress,
                City = entity.City,
                PinCode = entity.PinCode
            };

            return dto;
        }


        public async Task<NewConnectionForm> AddNewConnectionFormAsync(NewConnectionFormDTO newConnectionFormDTO)
        {
            if (_context.NewConnectionForms == null)
            {
                throw new Exception("Entity set 'ApplicationDbContext.NewConnectionForms' is null.");
            }
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var newConnectionForm = new NewConnectionForm
            {
                Name = newConnectionFormDTO.Name,
                Email = newConnectionFormDTO.Email,
                Dob = newConnectionFormDTO.Dob,
                MaritalStatus = newConnectionFormDTO.MaritalStatus,
                MobileNo = newConnectionFormDTO.MobileNo,
                Gender = newConnectionFormDTO.Gender,
                Nationality = newConnectionFormDTO.Nationality,
                Address = newConnectionFormDTO.Address,
                RationCardNo = newConnectionFormDTO.RationCardNo,
                Related = newConnectionFormDTO.Related,
                FirstName = newConnectionFormDTO.FirstName,
                LastName = newConnectionFormDTO.LastName,
                RelatedAddress = newConnectionFormDTO.RelatedAddress,
                City = newConnectionFormDTO.City,
                PinCode = newConnectionFormDTO.PinCode,
                UserId = userId
            };

            // Check if AddressProof is provided
            if (newConnectionFormDTO.AddressProof != null)
            {
                // Convert IFormFile to byte array
                byte[] fileBytes;
                using (var ms = new MemoryStream())
                {
                    await newConnectionFormDTO.AddressProof.CopyToAsync(ms);
                    fileBytes = ms.ToArray();
                }

                Account account = new Account(
                    "ddcpygqpz",
                    "355678217655168",
                    "oOu6_mF-OAC9vJs65scbc1c_e4M");

                Cloudinary cloudinary = new Cloudinary(account);

                // Upload byte array to Cloudinary
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription("address_proof", new MemoryStream(fileBytes)),
                    PublicId = "olympic_flag"
                };

                var uploadResult = await cloudinary.UploadAsync(uploadParams);

                // Set the AddressProof URL
                newConnectionForm.AddressProof = uploadResult.SecureUrl.ToString();
            }

            _context.NewConnectionForms.Add(newConnectionForm);
            await _context.SaveChangesAsync();

            return newConnectionForm;
        }


        public async Task<bool> DeleteNewConnectionFormAsync(int id)
        {
            if (_context.NewConnectionForms == null)
            {
                return false;
            }
            var newConnectionForm = await _context.NewConnectionForms.FindAsync(id);
            if (newConnectionForm == null)
            {
                return false;
            }

            _context.NewConnectionForms.Remove(newConnectionForm);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool NewConnectionFormExists(int id)
        {
            return (_context.NewConnectionForms?.Any(e => e.ConnectionNo == id)).GetValueOrDefault();
        }

        public int GenerateUniqueConnectionNo()
        {
            long timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            int randomNumber = random.Next(0, 9999);

            string connectionNoString = timestamp.ToString() + randomNumber.ToString("D8");

            if (connectionNoString.Length > 8)
            {
                connectionNoString = connectionNoString.Substring(0, 8);
            }
            else if (connectionNoString.Length < 8)
            {
                connectionNoString = connectionNoString.PadRight(8, '0');
            }

            return int.Parse(connectionNoString);
        }

        public async Task<bool> HasAppliedForConnection()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier); 
            var entities = await _context.NewConnectionForms
               .Where(form => form.UserId == userId)
               .ToListAsync();
            return entities.Count > 0;
        }
    }
}
