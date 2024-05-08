// pages/signin/page.tsx
import React from 'react';
import Layout from './layout';
import Appointments from './Appointments';
//import "../style/styles.css";
const AppointmentsPage: React.FC = () => {

return (
  <Layout title="Please set your dog a nice haircut meeting">
    <Appointments />
  </Layout>
);
};

export default AppointmentsPage;