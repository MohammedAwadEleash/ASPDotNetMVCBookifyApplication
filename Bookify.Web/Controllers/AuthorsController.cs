﻿namespace Bookify.Web.Controllers
{
    [Authorize(Roles = AppRoles.Archive)]
    public class AuthorsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IValidator<AuthorFormViewModel> _validator;
        private readonly IUnitOfWork _unitOfWor;
        private readonly IAuthorService _authorService;
        public AuthorsController(IMapper mapper, IValidator<AuthorFormViewModel> validator, IUnitOfWork unitOfWor, IAuthorService authorService)
        {
            _mapper = mapper;
            _validator = validator;
            _unitOfWor = unitOfWor;
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult Index()
        {


            var authors = _authorService.GetAll();
            var viewModel = _mapper.Map<IEnumerable<AuthorViewModel>>(authors);


            return View(viewModel);
        }
        [AjaxOnly]
        [HttpGet]

        public IActionResult Create()

        {
            return PartialView("_Form");


        }


        [HttpPost]

        public IActionResult Create(AuthorFormViewModel model)

        {
            var validationResult = _validator.Validate(model);
            if (!validationResult.IsValid)
                return BadRequest();




            var author = _authorService.Create(model.Name, User.GetUserId());

            var viewModel = _mapper.Map<AuthorViewModel>(author);


            return PartialView("_AuthorRow", viewModel);


        }


        [AjaxOnly]
        [HttpGet]
        public IActionResult Edit(int id)

        {

            var author = _authorService.GetById(id);
            if (author is null)
                return NotFound();



            var viewModel = _mapper.Map<AuthorFormViewModel>(author);




            return PartialView("_Form", viewModel);


        }

        [HttpPost]

        public IActionResult Edit(AuthorFormViewModel model)

        {

            var validationResult = _validator.Validate(model);
            if (!validationResult.IsValid)
                return BadRequest();


            var author = _authorService.Update(model.Id, model.Name, User.GetUserId());

            if (author is null)
                return NotFound();
            var viewModel = _mapper.Map<AuthorViewModel>(author);
            return PartialView("_AuthorRow", viewModel);
        }
        [HttpPost]
        public IActionResult ToggleStatus(int id)


        {

            var author = _authorService.ToggleStatus(id, User.GetUserId());
            if (author is null)
                return NotFound();

            ;

            return Ok(author.LastUpdatedOn.ToString());

        }
        public IActionResult AllowItem(AuthorFormViewModel model)
        {
            var isAllowed = _authorService.AllowAuthor(model.Id, model.Name);
            return Json(isAllowed);
        }



    }
}
