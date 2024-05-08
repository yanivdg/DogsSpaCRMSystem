// pages/signup/page.tsx
import React from 'react';
import Layout from './layout';
import SignupForm from './SignupForm';
//import "../styles/styles.css";
const SignUpPage: React.FC = () => {
  return (
    <Layout title="Please join our setisfied clients">
      <SignupForm />
    </Layout>
  );
};

export default SignUpPage;