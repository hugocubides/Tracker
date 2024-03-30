using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerDomain.Dto;
using TrackerDomain.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using TrackerDomain.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrackerDomain.Repository
{

    public class MovementRepository : IMovementRepository
    {

        private readonly TrackerAppBDContext _context;

        public MovementRepository(TrackerAppBDContext context)
        {
            _context = context;
        }

        public async Task<List<Movement>> GetAll()
        {
            return await _context.Movement
                .Include(t => t.MovementType)
                .Include(s => s.SourceBook)
                .Include(d => d.DestinationBook)
                .Include(d => d.DestinationOtherBook)
                .Include(p => p.ParentMovement)
                .Include(p => p.PayMovement)
                .Include(s => s.Status)
                .ToListAsync();
        }

        public async Task<Movement> GetOne(int? id)
        {
            return await _context.Movement
                .Include(t => t.MovementType)
                .Include(s => s.SourceBook)
                .Include(d => d.DestinationBook)
                .Include(d => d.DestinationOtherBook)
                .Include(p => p.ParentMovement)
                .Include(p => p.PayMovement)
                .Include(s => s.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async  Task<List<Movement>> GetAllByMovementType(int id)
        {
            return await _context.Movement
                .Include(t => t.MovementType)
                .Include(s => s.SourceBook)
                .Include(d => d.DestinationBook)
                .Include(d => d.DestinationOtherBook)
                .Include(p => p.ParentMovement)
                .Include(p => p.PayMovement)
                .Include(s => s.Status)
                .Where(t => t.MovementTypeId == id)
                .ToListAsync();
        }

        public int AddIncome(Movement objeto)
        {
            if (objeto.IsShared == false)
            {
                if (objeto.MovementTypeId != 1) return 0;

                var Book = _context.Book.Find(objeto.SourceBookId);
                if (Book == null) return 0;

                var objTransaction = _context.Database.BeginTransaction();
                {
                    Book.Balance += objeto.Value;
                    Book.UpdatedAt = objeto.UpdatedAt;
                    Book.UpdatedBy = objeto.UpdatedBy;
                    _context.ChangeTracker.Clear();
                    _context.Update(Book);
                    _context.Add(objeto);
                    if (_context.SaveChanges() > 0)
                    {
                        objTransaction.Commit();
                        return 1;
                    }
                    else
                    {
                        objTransaction.Rollback();
                        return 0;
                    }
                }
            }
            else 
            {
                //sin implementar
                return 0;
            }
        }

        public int RemoveIncome(Movement objeto)
        {
            if (objeto.IsShared == false)
            {
                if (objeto.MovementTypeId != 1) return 0;

                var Book = _context.Book.Find(objeto.SourceBookId);
                if (Book == null) return 0;

                var objTransaction = _context.Database.BeginTransaction();
                Book.Balance -= objeto.Value;
                Book.UpdatedAt = objeto.UpdatedAt;
                Book.UpdatedBy = objeto.UpdatedBy;
                _context.ChangeTracker.Clear();
                _context.Update(Book);
                _context.Remove(objeto);
                if (_context.SaveChanges() > 0)
                {
                    objTransaction.Commit();
                    return 1;
                }
                else
                {
                    objTransaction.Rollback();
                    return 0;
                }
            }
            else
            {
                //sin implementar
                return 0;
            }

        }

        public int UpdateIncome(Movement newMovement)
        {
            if (newMovement.IsShared == false)
            {
                if (newMovement.MovementTypeId != 1) return 0;

                var newBook = _context.Book.Find(newMovement.SourceBookId);
                if (newBook == null) return 0;

                var objTransaction = _context.Database.BeginTransaction();
                {
                    var oldMovement = _context.Movement.FirstOrDefault(x => x.Id == newMovement.Id);
                    if(oldMovement is null) return 0;
                    _context.ChangeTracker.Clear();
                    if (oldMovement.SourceBookId != newMovement.SourceBookId)
                    {
                        var oldBook = _context.Book.Find(oldMovement.SourceBookId);
                        oldBook.Balance -= oldMovement.Value;
                        oldBook.UpdatedAt = newMovement.UpdatedAt;
                        oldBook.UpdatedBy = newMovement.UpdatedBy;
                        _context.Update(oldBook);

                        newBook.Balance += newMovement.Value;
                        newBook.UpdatedAt = newMovement.UpdatedAt;
                        newBook.UpdatedBy = newMovement.UpdatedBy;
                        _context.Update(newBook);
                    }
                    else 
                    {
                        newBook.Balance -= oldMovement.Value;
                        newBook.Balance += newMovement.Value;
                        _context.Update(newBook);
                    }

                    _context.Update(newMovement);
                    if (_context.SaveChanges() > 0)
                    {
                        objTransaction.Commit();
                        return 1;
                    }
                    else
                    {
                        objTransaction.Rollback();
                        return 0;
                    }
                }
            }
            else
            {
                //sin implementar
                return 0;
            }
        }

        public int AddExpense(Movement objeto)
        {
            if (objeto.IsShared == false)
            {
                if (objeto.MovementTypeId != 2) return 0;

                var Book = _context.Book.Find(objeto.SourceBookId);
                if (Book == null) return 0;

                var objTransaction = _context.Database.BeginTransaction();
                {
                    Book.Balance -= objeto.Value;
                    Book.UpdatedAt = objeto.UpdatedAt;
                    Book.UpdatedBy = objeto.UpdatedBy;
                    _context.ChangeTracker.Clear();
                    _context.Update(Book);
                    _context.Add(objeto);
                    if (_context.SaveChanges() > 0)
                    {
                        objTransaction.Commit();
                        return 1;
                    }
                    else
                    {
                        objTransaction.Rollback();
                        return 0;
                    }
                }
            }
            else
            {
                //sin implementar
                return 0;
            }
        }

        public int RemoveExpense(Movement objeto)
        {
            if (objeto.IsShared == false)
            {
                if (objeto.MovementTypeId != 1) return 0;

                var Book = _context.Book.Find(objeto.SourceBookId);
                if (Book == null) return 0;

                var objTransaction = _context.Database.BeginTransaction();
                Book.Balance += objeto.Value;
                Book.UpdatedAt = objeto.UpdatedAt;
                Book.UpdatedBy = objeto.UpdatedBy;
                _context.ChangeTracker.Clear();
                _context.Update(Book);
                _context.Remove(objeto);
                if (_context.SaveChanges() > 0)
                {
                    objTransaction.Commit();
                    return 1;
                }
                else
                {
                    objTransaction.Rollback();
                    return 0;
                }
            }
            else
            {
                //sin implementar
                return 0;
            }
        }

        public int UpdateExpense(Movement newMovement)
        {
            if (newMovement.IsShared == false)
            {
                if (newMovement.MovementTypeId != 2) return 0;

                var newBook = _context.Book.Find(newMovement.SourceBookId);
                if (newBook == null) return 0;

                var objTransaction = _context.Database.BeginTransaction();
                {
                    var oldMovement = _context.Movement.FirstOrDefault(x => x.Id == newMovement.Id);
                    if (oldMovement is null) return 0;
                    _context.ChangeTracker.Clear();
                    if (oldMovement.SourceBookId != newMovement.SourceBookId)
                    {
                        var oldBook = _context.Book.Find(oldMovement.SourceBookId);
                        oldBook.Balance -= oldMovement.Value;
                        oldBook.UpdatedAt = newMovement.UpdatedAt;
                        oldBook.UpdatedBy = newMovement.UpdatedBy;
                        _context.Update(oldBook);

                        newBook.Balance += newMovement.Value;
                        newBook.UpdatedAt = newMovement.UpdatedAt;
                        newBook.UpdatedBy = newMovement.UpdatedBy;
                        _context.Update(newBook);
                    }
                    else
                    {
                        newBook.Balance -= oldMovement.Value;
                        newBook.Balance += newMovement.Value;
                        newBook.UpdatedAt = newMovement.UpdatedAt;
                        newBook.UpdatedBy = newMovement.UpdatedBy;
                        _context.Update(newBook);
                    }

                    _context.Update(newMovement);
                    if (_context.SaveChanges() > 0)
                    {
                        objTransaction.Commit();
                        return 1;
                    }
                    else
                    {
                        objTransaction.Rollback();
                        return 0;
                    }
                }
            }
            else
            {
                //sin implementar
                return 0;
            }
        }

        public int AddTransfer(Movement objeto)
        {
            if (objeto.IsShared == false)
            {
                if (objeto.MovementTypeId != 3) return 0;

                var sourceBook = _context.Book.Find(objeto.SourceBookId);
                var destinationBook = _context.Book.Find(objeto.DestinationBookId);
                if (sourceBook == null || destinationBook == null) return 0;

                var objTransaction = _context.Database.BeginTransaction();
                {
                    sourceBook.Balance -= objeto.Value;
                    sourceBook.UpdatedAt = objeto.UpdatedAt;
                    sourceBook.UpdatedBy = objeto.UpdatedBy;

                    destinationBook.Balance += objeto.Value;
                    destinationBook.UpdatedAt = objeto.UpdatedAt;
                    destinationBook.UpdatedBy = objeto.UpdatedBy;

                    _context.ChangeTracker.Clear();
                    _context.Update(sourceBook);
                    _context.Update(destinationBook);

                    _context.Add(objeto);
                    if (_context.SaveChanges() > 0)
                    {
                        objTransaction.Commit();
                        return 1;
                    }
                    else
                    {
                        objTransaction.Rollback();
                        return 0;
                    }
                }
            }
            else
            {
                //sin implementar
                return 0;
            }
        }

        public int RemoveTransfer(Movement objeto)
        {
            if (objeto.IsShared == false)
            {
                if (objeto.MovementTypeId != 3) return 0;

                var sourceBook = _context.Book.Find(objeto.SourceBookId);
                var destinationBook = _context.Book.Find(objeto.DestinationBookId);
                if (sourceBook == null || destinationBook == null) return 0;

                var objTransaction = _context.Database.BeginTransaction();

                sourceBook.Balance += objeto.Value;
                sourceBook.UpdatedAt = objeto.UpdatedAt;
                sourceBook.UpdatedBy = objeto.UpdatedBy;

                destinationBook.Balance -= objeto.Value;
                destinationBook.UpdatedAt = objeto.UpdatedAt;
                destinationBook.UpdatedBy = objeto.UpdatedBy;

                _context.ChangeTracker.Clear();
                _context.Update(sourceBook);
                _context.Update(destinationBook);

                _context.Remove(objeto);
                if (_context.SaveChanges() > 0)
                {
                    objTransaction.Commit();
                    return 1;
                }
                else
                {
                    objTransaction.Rollback();
                    return 0;
                }
            }
            else
            {
                //sin implementar
                return 0;
            }
        }

        public int UpdateTransfer(Movement newMovement)
        {
            if (newMovement.IsShared == false)
            {
                if (newMovement.MovementTypeId != 3) return 0;

                var newSourceBook = _context.Book.Find(newMovement.SourceBookId);
                var newDestinationBook = _context.Book.Find(newMovement.DestinationBookId);
                if (newSourceBook == null || newDestinationBook == null) return 0;

                var objTransaction = _context.Database.BeginTransaction();
                {
                    var oldMovement = _context.Movement.FirstOrDefault(x => x.Id == newMovement.Id);
                    if (oldMovement is null) return 0;

                    var oldSourceBook = _context.Book.Find(oldMovement.SourceBookId);
                    var oldDestinationBook = _context.Book.Find(oldMovement.DestinationBookId);
                    if (oldSourceBook == null || oldDestinationBook == null) return 0;

                    _context.ChangeTracker.Clear();

                    //Source
                    if (newSourceBook.Id != oldSourceBook.Id)
                    {
                        oldSourceBook.Balance += oldMovement.Value;
                        oldSourceBook.UpdatedAt = newMovement.UpdatedAt;
                        oldSourceBook.UpdatedBy = newMovement.UpdatedBy;
                        _context.Update(oldSourceBook);

                        newSourceBook.Balance -= newMovement.Value;
                        newSourceBook.UpdatedAt = newMovement.UpdatedAt;
                        newSourceBook.UpdatedBy = newMovement.UpdatedBy;
                        _context.Update(newSourceBook);
                    }
                    else
                    {
                        newSourceBook.Balance += oldMovement.Value;
                        newSourceBook.Balance -= newMovement.Value;
                        newSourceBook.UpdatedAt = newMovement.UpdatedAt;
                        newSourceBook.UpdatedBy = newMovement.UpdatedBy;
                        _context.Update(newSourceBook);
                    }

                    //Destination --ok rdo
                    if (newDestinationBook.Id != oldDestinationBook.Id)
                    {
                        oldDestinationBook.Balance -= oldMovement.Value;
                        oldDestinationBook.UpdatedAt = newMovement.UpdatedAt;
                        oldDestinationBook.UpdatedBy = newMovement.UpdatedBy;
                        _context.Update(oldDestinationBook);

                        newDestinationBook.Balance += newMovement.Value;
                        newDestinationBook.UpdatedAt = newMovement.UpdatedAt;
                        newDestinationBook.UpdatedBy = newMovement.UpdatedBy;
                        _context.Update(newDestinationBook);
                    }
                    else
                    {
                        newDestinationBook.Balance -= oldMovement.Value;
                        newDestinationBook.Balance += newMovement.Value;
                        newDestinationBook.UpdatedAt = newMovement.UpdatedAt;
                        newDestinationBook.UpdatedBy = newMovement.UpdatedBy;
                        _context.Update(newDestinationBook);
                    }

                    _context.Update(newMovement);
                    if (_context.SaveChanges() > 0)
                    {
                        objTransaction.Commit();
                        return 1;
                    }
                    else
                    {
                        objTransaction.Rollback();
                        return 0;
                    }
                }
            }
            else
            {
                //sin implementar
                return 0;
            }
        }
    }
}
