using Microsoft.AspNetCore.Mvc;
using MVCData.Data;
using MVCModel.Models;
using MVCData.Repository;

using Microsoft.EntityFrameworkCore;


namespace PracticeMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MoviesController : Controller
    {
        // below Comment was not using repository. It is directly using applictaionDbcontext

        //private readonly ApplicationDbContext _context;

        //public MoviesController(ApplicationDbContext context)
        //{
        //    _context = context;

        //}


        //-----------------This is Before Unit Of work Interface--------------------------------------
        //private readonly IMovieRepository _movieRepo;
        //public MoviesController(IMovieRepository db)
        //{
        //    _movieRepo = db;
        //}
        //--------------------------------------------------------

        // ------------------After UnitOfWork below -- because we can access movie repository from Unit of work so ---------------

        private readonly IUnitOfWork _unitOfWork;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

            // var obj = _context.M_movies.ToList();

            // var obj = _movieRepo.GetAll().ToList(); //-- without unit of work

            var obj = _unitOfWork.MovieUnit.GetAll().ToList();

            return View(obj);
        }

        //get
        public IActionResult Add()
        {


            return View();

        }

        //post

        [HttpPost]
        public IActionResult Add(Movies mv)
        {

            if (ModelState.IsValid)
            {
                //_context.M_movies.Add(mv);
                //_context.SaveChanges();

                //  _movieRepo.Add(mv); //-- without unit of work
                //	_movieRepo.Save(); //-- without unit of work

                _unitOfWork.MovieUnit.Add(mv);
                _unitOfWork.Save();

                TempData["Added"] = "Movie Added Successfully";

                return RedirectToAction("Index");
            }
            return View(mv);

        }


        //get
        public IActionResult Edit(int? id)
        {

            //var mov = _context.M_movies.FirstOrDefault(a => a.MovieId == id);
            //var mov1 = _context.M_movies.SingleOrDefault(a => a.MovieId == id);

            //var obj = _context.M_movies.Find(id);


            // var obj = _movieRepo.Get(u => u.MovieId == id); //-- without unit of work

            var obj = _unitOfWork.MovieUnit.Get(u => u.MovieId == id);


            return View(obj);




        }



        //post
        [HttpPost]
        public IActionResult Edit(Movies mvc)
        {

            if (ModelState.IsValid)
            {
                //_context.M_movies.Update(mvc);
                //_context.SaveChanges();

                // _movieRepo.Update(mvc); //-- without unit of work
                //	_movieRepo.Save();  //-- without unit of work

                _unitOfWork.MovieUnit.Update(mvc);
                _unitOfWork.Save();


                TempData["Edited"] = "Movie Edited Successfully";
                return RedirectToAction("Index");
            }
            return View(mvc);


        }

        //get
        public IActionResult Delete(int? id)
        {
            //var obj = _context.M_movies.Find(id);

            // var obj = _movieRepo.Get(a => a.MovieId == id); //-- without unit of work

            var obj = _unitOfWork.MovieUnit.Get(a => a.MovieId == id);
            return View(obj);

        }


        //post 
        [HttpPost]
        public IActionResult DeletePost(Movies mv)
        {
            //_context.M_movies.Remove(mv);
            //_context.SaveChanges();

            // _movieRepo.Delete(mv); //-- without unit of work
            //_movieRepo.Save(); //-- without unit of work

            _unitOfWork.MovieUnit.Delete(mv);
            _unitOfWork.Save();

            TempData["Deleted"] = "Movie Deleted Successfully";
            return RedirectToAction("Index");
        }

        ////post 
        //[HttpPost]
        //public IActionResult DeletePost(int id)
        //{
        //    _context.M_movies.Remove(mv);
        //var obj = _context.M_movies.Find(id);

        //        if(obj != null)
        //        {
        //_context.M_movies.Remove(obj);
        //_context.SaveChanges();
        //TempData["Deleted"] = "Movie Deleted Successfully";
        //return RedirectToAction("Index");

        //         }
        //        return View(obj);
        //}


        // One Click Delete below

        //post 
        [HttpPost]
        public IActionResult DeletePostOneClick(int id)
        {

            //var obj = _context.M_movies.Find(id);
            //var obj = _movieRepo.Get( a => a.MovieId == id); //-- without unit of work

            var obj = _unitOfWork.MovieUnit.Get(a => a.MovieId == id);



            if (obj != null)
            {
                //_context.M_movies.Remove(obj);
                //_context.SaveChanges();

                // _movieRepo.Delete(obj); //-- without unit of work
                //_movieRepo.Save(); //-- without unit of work

                _unitOfWork.MovieUnit.Delete(obj);
                _unitOfWork.Save();
                TempData["Deleted"] = "Movie Deleted Successfully";
                return RedirectToAction("Index");

            }
            return View(obj);

        }

    }
}
