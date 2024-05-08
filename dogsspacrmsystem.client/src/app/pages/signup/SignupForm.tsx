"use client"

import React, { useState } from 'react';
import { FormEvent } from 'react';

const inputClass = "mt-1 block w-full px-3 py-2 border border-zinc-300 dark:border-zinc-600 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm";
const labelClass = "block text-sm font-medium text-zinc-700 dark:text-zinc-300";
const buttonClass = "w-full bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline";

const SignUpForm = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [firstName, setFirstName] = useState('');
  const [isLoading, setIsLoading] = useState(false);
  const [errorMessage, setErrorMessage] = useState('');

  const handleSubmit = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault(); // Prevent default form submission

    setIsLoading(true);
    setErrorMessage(''); // Clear any previous errors

    try {
      // Extract data from form fields
      const formData = new FormData(event.currentTarget);
      const username = formData.get('username') as string;
      const password = formData.get('password') as string;
      const firstName = formData.get('firstName') as string;

      const response = await fetch('http://localhost/7071/user/signup', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, password, firstName }),
      });

      if (!response.ok) {
        throw new Error(`API request failed with status ${response.status}`);
      }

      const data = await response.json();
      console.log('Signup successful:', data); // Handle successful response (optional)

      // Reset form after successful submission (optional)
      setUsername('');
      setPassword('');
      setFirstName('');
    } catch (error) {
      console.error('Signup error:', error);
      setErrorMessage((error as Error).message); // Display error message
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="flex flex-col items-center justify-center min-h-screen bg-zinc-100 dark:bg-zinc-800">
      <div className="max-w-md w-full p-6 bg-white dark:bg-zinc-700 rounded-lg shadow-lg">
        <h2 className="text-2xl font-bold text-center mb-4">Sign Up</h2>
        <form className="space-y-4" onSubmit={handleSubmit}>
          <div>
            <label htmlFor="username" className={labelClass}>
              Username
            </label>
            <input
              type="text"
              id="username"
              name="username"
              className={inputClass}
              placeholder="Enter your username"
              value={username}
              onChange={(e) => setUsername(e.target.value)}
            />
          </div>
          <div>
            <label htmlFor="password" className={labelClass}>
              Password
            </label>
            <input
              type="password"
              id="password"
              name="password"
              className={inputClass}
              placeholder="Enter your password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />
          </div>
          <div>
            <label htmlFor="firstName" className={labelClass}>
              First Name
            </label>
            <input
              type="text"
              id="firstName"
              name="firstName"
              className={inputClass}
              placeholder="Enter your first name"
              value={firstName}
              onChange={(e) => setFirstName(e.target.value)}
            />
          </div>
          <button type="submit" className={buttonClass} disabled={isLoading}>
            {isLoading ? 'Loading...' : 'Sign Up'}
          </button>
          {errorMessage && <p className="text-red-500">{errorMessage}</p>}
        </form>
      </div>
      </div>
    );
}
export default SignUpForm;

