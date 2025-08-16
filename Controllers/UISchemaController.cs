using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PowerAppsUIValues.Models;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PowerAppsUIValues.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UISchemaController(AppDbContext context) : ControllerBase
    {
        // GET: api/<UISchemaController>
        [HttpGet]
        public async Task<List<UISchema>> GetUISchemas()
        {
            return await context.UISchemas.ToListAsync<UISchema>();
        }

        // GET api/<UISchemaController>/5
        [HttpGet("{id}")]
        public async Task<UISchema> GetUISchema(int id)
        {
            var uiSchema = await context.UISchemas.FindAsync(id);

            if (uiSchema == null) throw new NullReferenceException();

            return uiSchema;
        }
        // POST api/<UISchemaController>
        [HttpPost]
        public async Task<ActionResult> CreateUISchema([FromBody] UISchema uiSchema)
        {
            await context.UISchemas.AddAsync(uiSchema);
            await context.SaveChangesAsync();
            return NoContent();
        }

        // PUT api/<UISchemaController>/5
        [HttpPut()]
        public async Task<ActionResult> EditUISchema([FromBody] UISchema uiSchema)
        {
            //Use automapper here to map 
            var originalUISchema = await context.UISchemas.FindAsync(uiSchema.Id);
            if (originalUISchema == null) throw new NullReferenceException();

            originalUISchema.Name = uiSchema.Name;
            originalUISchema.TextColorPrimary = uiSchema.TextColorPrimary;
            originalUISchema.TextColorSecondary = uiSchema.TextColorSecondary;
            originalUISchema.TextColorTertiary = uiSchema.TextColorTertiary;
            originalUISchema.TextColorTertiaryLight = uiSchema.TextColorTertiaryLight;
            originalUISchema.TextColorTertiaryDark = uiSchema.TextColorTertiaryDark;
            originalUISchema.BackgroundColorPrimary = uiSchema.BackgroundColorPrimary;
            originalUISchema.BackgroundColorSecondary = uiSchema.BackgroundColorSecondary;
            originalUISchema.BackgroundColorTertiary = uiSchema.BackgroundColorTertiary;
            originalUISchema.BackgroundColorTertiaryLight = uiSchema.BackgroundColorTertiaryLight;
            originalUISchema.BackgroundColorTertiaryDark = uiSchema.BackgroundColorTertiaryDark;
            originalUISchema.PrimaryFontFamily = uiSchema.PrimaryFontFamily;
            originalUISchema.SecondaryFontFamily = uiSchema.SecondaryFontFamily;
            originalUISchema.TertiaryFontFamily = uiSchema.TertiaryFontFamily;

            await context.SaveChangesAsync();

            return Ok();
        }

        // DELETE api/<UISchemaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            UISchema uiSchema = await context.UISchemas.FindAsync(id);
            if (uiSchema == null) throw new NullReferenceException();
            context.UISchemas.Remove(uiSchema);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
