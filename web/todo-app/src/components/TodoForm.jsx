import React, { useState, useEffect } from 'react';
import './TodoForm.css';

const TodoForm = ({ todo, onSubmit, onCancel }) => {
  const [title, setTitle] = useState('');
  const [description, setDescription] = useState('');
  
  // If we receive a todo for editing, populate the form fields
  useEffect(() => {
    if (todo) {
      setTitle(todo.title);
      setDescription(todo.description || '');
    }
  }, [todo]);
  
  const handleSubmit = (e) => {
    e.preventDefault();
    
    if (!title.trim()) return;
    
    onSubmit({
      title: title.trim(),
      description: description.trim()
    });
    
    setTitle('');
    setDescription('');
  };
  
  return (
    <form onSubmit={handleSubmit} className="todo-form">
      <h2>{todo ? 'Edit Todo' : 'Add New Todo'}</h2>
      
      <div className="form-group">
        <label htmlFor="title">Title</label>
        <input
          type="text"
          id="title"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
          placeholder="Enter a title"
          required
        />
      </div>
      
      <div className="form-group">
        <label htmlFor="description">Description (optional)</label>
        <textarea
          id="description"
          value={description}
          onChange={(e) => setDescription(e.target.value)}
          placeholder="Enter a description"
          rows={3}
        />
      </div>
      
      <div className="form-actions">
        <button type="button" onClick={onCancel} className="cancel-button">
          Cancel
        </button>
        <button type="submit" className="submit-button">
          {todo ? 'Update' : 'Add'}
        </button>
      </div>
    </form>
  );
};

export default TodoForm;