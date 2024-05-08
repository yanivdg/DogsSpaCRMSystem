"use client"
import React, { FormEvent, useState } from 'react';
import { useRouter } from 'next/router';

interface SigninCred {
  username: string;
  password: string;
}

const inputClasses = "mt-1 block w-full px-3 py-2 border dark:border-zinc-700 rounded-md shadow-sm focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm";
const labelClasses = "block text-sm font-medium text-zinc-700 dark:text-zinc-300";
const buttonClasses = "w-full bg-blue-500 text-white p-3 rounded-md hover:bg-blue-600 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-opacity-50";
const containerClasses = "min-h-screen flex items-center justify-center bg-zinc-100 dark:bg-zinc-800";
const formContainerClasses = "bg-white dark:bg-zinc-900 shadow-md rounded-lg p-8 max-w-md w-full";																				


const SignInForm = () => { 
  const [formData, setFormData] = useState<SigninCred>({ username: '', password: '' });

  const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFormData({ ...formData, [event.target.name]: event.target.value });
  };

  const handleSubmit = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    try {
      const response = await fetch('http://localhost/7071/user/signin', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(formData),
      });
      if (response.ok) {
        const router = useRouter();
        // Handle successful sign-in (e.g., redirect, display success message)
        console.log('Sign in successful!');
        router.push('/pages/appointments');
      } else {
        // Handle errors (e.g., display error message)
        const errorData = await response.json();
        console.error('Sign in failed:', errorData.message || 'Unknown error');
      }
    } catch (error) {
      console.error('Error during sign-in request:', error);
    }
    
  };

  return (
    <div className={containerClasses}>
      <div className={formContainerClasses}>
        <h2 className="text-2xl font-bold text-zinc-800 dark:text-zinc-200 mb-8 text-center">Sign In</h2>
        <form onSubmit={handleSubmit}>
          <div className="mb-4">
            <label htmlFor="username" className={labelClasses}>
              Username
            </label>
            <input
              type="text"
              id="username"
              name="username"
              className={inputClasses}
              placeholder="Enter your username"
              onChange={handleChange}
            />
          </div>
          <div className="mb-6">
            <label htmlFor="password" className={labelClasses}>
              Password
            </label>
            <input
              type="password"
              id="password"
              name="password"
              className={inputClasses}
              placeholder="Enter your password"
              onChange={handleChange}
            />
          </div>
          <button type="submit" className={buttonClasses}>
            Sign In
          </button>
         </form>
      </div>
    </div>
  );
};

export default SignInForm;
