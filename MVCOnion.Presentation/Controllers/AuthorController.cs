using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCOnion.Application.DTOs.AuthorDtos;
using MVCOnion.Application.DTOs.BookDtos;
using MVCOnion.Application.IServices;
using MVCOnion.Presentation.ViewModels.AuthorVms;

namespace MVCOnion.Presentation.Controllers
{
    public class AuthorController : Controller
    {

        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public AuthorController(IAuthorService authorService, IBookService bookService)
        {
            _authorService = authorService;
            _bookService = bookService;
        }

        // GET: AuthorController
        public async Task<ActionResult> Index()
        {
            List<AuthorListVm> authorList = _authorService.AuthorLists().Result.Select(author => new AuthorListVm(author)).ToList();
            return View(authorList);
        }

        // GET: AuthorController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            AuthorCreateDto authorCreateDto = await _authorService.GetByAuthorId(id);
            List<BookListDto> bookListDtos = _bookService.GetBooksAuthorId(id).Result.ToList();
            return View(new AuthorDetailVm(authorCreateDto,bookListDtos));
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AuthorCreateDto authorCreateDto,IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var bookList = collection["book"].ToList();
                    bool authorCreate = await _authorService.AuthorCreate(authorCreateDto);
                    if (authorCreate && bookList.Count>0)
                    {
                        int authorId = await _authorService.GetIdByAuthorNameAndLastName(authorCreateDto.FirstName, authorCreateDto.LastName);
                        List<BookCreateDto> bookCreateDtos = bookList.Select(bookName => new BookCreateDto
                        {
                            BookName = bookName,
                            AuthorId = authorId,
                        }).ToList();

                        bool bookCreateRange = await _bookService.BookCreateRange(bookCreateDtos);
                        if (!bookCreateRange)
                        {
                            return View(authorCreateDto);
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(authorCreateDto);
            }
        }

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
