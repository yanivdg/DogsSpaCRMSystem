"use client"

import React, { useState } from 'react';

const userAppointmentListData = [
    { name: 'John Doe', scheduledDate: '10/15/2021' },
    { name: 'Jane Smith', scheduledDate: '10/16/2021' },
    { name: 'Michael Johnson', scheduledDate: '10/17/2021' }
];

const popupStyles = 'hidden fixed top-0 left-0 w-full h-full bg-black bg-opacity-50 flex items-center justify-center';
const cardStyles = 'bg-white dark:bg-zinc-800 p-4 rounded-lg shadow-md';
const textStyles = 'text-lg font-semibold';
const subTextStyles = 'text-sm text-zinc-500 dark:text-zinc-400';
const buttonStyles = 'mt-4 bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded';

const UserAppointmentList = () => {
    const [popupData, setPopupData] = useState({ userName: '', appointmentTime: '', requestTime: '' });

    const handleUserClick = (name: string, scheduledDate: string) => {
        const requestTime = new Date().toLocaleString();
        setPopupData({ userName: name, appointmentTime: scheduledDate, requestTime });
    };

    const handleClosePopup = () => {
        setPopupData({ userName: '', appointmentTime: '', requestTime: '' });
    };

    return (
        <div>
            <div id="userAppointmentList" className={`${cardStyles} bg-white dark:bg-zinc-800 p-4 rounded-lg shadow-md`}>
                <h2 className="text-2xl font-bold mb-4">User Appointment List</h2>
                {userAppointmentListData.map((user, index) => (
                    <div key={index} className="flex items-center justify-between border-b border-zinc-300 dark:border-zinc-700 pb-2 mb-4">
                        <p className={textStyles} onClick={() => handleUserClick(user.name, user.scheduledDate)}>{user.name}</p>
                        <p className={subTextStyles}>Scheduled for: {user.scheduledDate}</p>
                    </div>
                ))}
            </div>

            <div id="popup" className={popupData.userName ? popupStyles : ''}>
                <div className={cardStyles}>
                    <p id="popupUserName" className={textStyles}>{popupData.userName}</p>
                    <p id="popupAppointmentTime" className={subTextStyles}>Appointment Time: {popupData.appointmentTime}</p>
                    <p id="popupRequestTime" className={subTextStyles}>Request Time: {popupData.requestTime}</p>
                    <button id="closePopup" className={buttonStyles} onClick={handleClosePopup}>Close</button>
                </div>
            </div>
        </div>
    );
};

export default UserAppointmentList;