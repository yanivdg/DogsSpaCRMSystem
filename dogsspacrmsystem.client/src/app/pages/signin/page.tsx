// pages/signin/page.tsx
import React from 'react';
import Layout from './layout';
import SigninForm from './SigninForm';
//import "../styles/styles.css";
const SignInPage: React.FC = () => {

return (
  <Layout title="Please set your dog a nice haircut meeting">
    <SigninForm />
  </Layout>
);
};

export default SignInPage;