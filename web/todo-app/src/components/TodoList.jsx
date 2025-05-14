import React, { useState, useEffect } from 'react';
import { api } from '../services/api';
import TodoItem from './TodoItem';
import TodoForm from './TodoForm';
import './TodoList.css';

const TodoList = () => {
  const [todos, setTodos] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState(null);
  const [showForm, setShowForm] = useState(false);
  const [editingTodo, setEditingTodo] = useState(null);
  
  // Fetch todos from the API when the component mounts
  const fetchTodos = async () => {
    try {
      setIsLoading(true);
      const data = await api.getAllTodos();
      setTodos(data);
      setError(null);
    } catch (err) {
      setError('Failed to fetch todos. Please try again later.');
      console.error(err);
    } finally {
      setIsLoading(false);
    }
  };
  
  useEffect(() => {
    fetchTodos();
  }, []);
  
  // Handle adding a new todo
  const handleAddTodo = async (data) => {
    try {
      const newTodo = await api.createTodo(data);
      setTodos([...todos, newTodo]);
      setShowForm(false);
    } catch (err) {
      setError('Failed to add todo. Please try again.');
      console.error(err);
    }
  };
  
  // Handle updating a todo
  const handleUpdateTodo = async (id, data) => {
    try {
      await api.updateTodo(id, data);
      fetchTodos(); // Refresh the list
      setEditingTodo(null);
      setShowForm(false);
    } catch (err) {
      setError('Failed to update todo. Please try again.');
      console.error(err);
    }
  };
  
  // Handle toggling a todo's completion status
  const handleToggleTodo = async (id, isCompleted) => {
    const todo = todos.find(t => t.id === id);
    if (!todo) return;
    
    try {
      await api.updateTodo(id, {
        title: todo.title,
        description: todo.description,
        isCompleted
      });
      
      // Update local state optimistically
      setTodos(todos.map(t => 
        t.id === id ? { ...t, isCompleted } : t
      ));
      
      // Refresh to get the updated completedAt value
      fetchTodos();
    } catch (err) {
      setError('Failed to update todo. Please try again.');
      console.error(err);
    }
  };
  
  // Handle deleting a todo
  const handleDeleteTodo = async (id) => {
    if (!window.confirm('Are you sure you want to delete this todo?')) return;
    
    try {
      await api.deleteTodo(id);
      setTodos(todos.filter(t => t.id !== id));
    } catch (err) {
      setError('Failed to delete todo. Please try again.');
      console.error(err);
    }
  };
  
  // Edit a todo (open form with todo data)
  const handleEditTodo = (todo) => {
    setEditingTodo(todo);
    setShowForm(true);
  };
  
  // Cancel the form
  const handleCancelForm = () => {
    setShowForm(false);
    setEditingTodo(null);
  };
  
  return (
    <div className="todo-list-container">
      <div className="todo-header">
        <h1>My Todo List</h1>
        
        {!showForm && (
          <button onClick={() => setShowForm(true)} className="add-button">
            Add Todo
          </button>
        )}
      </div>
      
      {error && (
        <div className="error-message">
          <p>{error}</p>
        </div>
      )}
      
      {showForm && (
        <TodoForm 
          todo={editingTodo} 
          onSubmit={(data) => {
            if (editingTodo) {
              handleUpdateTodo(editingTodo.id, { ...data, isCompleted: editingTodo.isCompleted });
            } else {
              handleAddTodo(data);
            }
          }}
          onCancel={handleCancelForm}
        />
      )}
      
      {isLoading ? (
        <div className="loading-spinner">
          <div className="spinner"></div>
          <p>Loading todos...</p>
        </div>
      ) : todos.length > 0 ? (
        <div className="todo-items">
          {todos.map(todo => (
            <TodoItem
              key={todo.id}
              todo={todo}
              onToggle={handleToggleTodo}
              onEdit={handleEditTodo}
              onDelete={handleDeleteTodo}
            />
          ))}
        </div>
      ) : (
        <div className="empty-state">
          <div className="empty-icon">📋</div>
          <p>No todos yet. Create one by clicking the "Add Todo" button.</p>
        </div>
      )}
    </div>
  );
};

export default TodoList;