'use client';
import Link from "next/link";
import React, { useState, useEffect } from "react";

interface Connection {
  id: number;
  status: string;
}

interface Booking {
  id: number;
  status: string;
}

interface LPGDelivery {
  id: number;
}

interface UserDetails {
  id: number;
}

const AdminDashboard: React.FC = () => {
  const [totalNewConnections, setTotalNewConnections] = useState<number>(0);
  const [totalOnHoldConnections, setTotalOnHoldConnections] = useState<number>(0);
  const [totalRejectedConnections, setTotalRejectedConnections] = useState<number>(0);
  const [totalNewBookings, setTotalNewBookings] = useState<number>(0);
  const [totalConfirmedBookings, setTotalConfirmedBookings] = useState<number>(0);
  const [totalCanceledBookings, setTotalCanceledBookings] = useState<number>(0);
  const [totalAssignedBookings, setTotalAssignedBookings] = useState<number>(0);
  const [totalDeliveredLPG, setTotalDeliveredLPG] = useState<number>(0);
  const [totalStaff, setTotalStaff] = useState<number>(0);
  const [totalUsers, setTotalUsers] = useState<number>(0);

  useEffect(() => {
    fetch('http://localhost:5057/api/Admin/Dashboard')
      .then(response => {
        if (!response.ok) {
          throw new Error('Failed to fetch data');
        }
        return response.json();
      })
      .then(data => {
        setTotalNewConnections(data.TotalNewConnection);
        setTotalOnHoldConnections(data.TotalOnHoldConnection);
        setTotalRejectedConnections(data.TotalRejectedConnection);
        // setTotalNewBookings(data.totalNewBookings);
        // setTotalConfirmedBookings(data.totalConfirmedBookings);
        // setTotalCanceledBookings(data.totalCanceledBookings);
        // setTotalAssignedBookings(data.totalAssignedBookings);
        // setTotalDeliveredLPG(data.totalDeliveredLPG);
        // setTotalStaff(data.totalStaff);
        setTotalUsers(data.TotalRegisteredUsers);
      })
      .catch(error => {
        console.error('Error fetching data:', error);
      });
  }, []);

  return (
    <div className="bg-white px-6 py-8 sm:px-8">
      <h2 className="text-3xl font-bold text-gray-900 mb-6">Admin Dashboard</h2>
    

     <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4 my-5">
        <div className="bg-gray-100 rounded-md p-4">
          <strong className="my-1">Total New Connections</strong>
          <p className="my-1">{totalNewConnections}</p>
          <button className="view-details-btn bg-blue-500 text-white px-4 py-2 rounded-md">
            <Link href="/admin/Connection">View Details</Link>
          </button>
        </div>
        <div className="bg-gray-100 rounded-md p-4">
          <strong className="my-1">Total OnHold Connections</strong>
          <p className="my-1">{totalOnHoldConnections}</p>
          <button className="view-details-btn bg-yellow-500 text-white px-4 py-2 rounded-md">
          <Link href="/admin/Connection">View Details</Link>
          </button>
        </div>
        
        <div className="bg-gray-100 rounded-md p-4">
          <strong className="my-1">Total Rejected Connections</strong>
          <p className="my-1">{totalRejectedConnections}</p>

          <button className="view-details-btn bg-red-500 text-white px-4 py-2 rounded-md">
          <Link href="/admin/Connection">View Details</Link>
          </button>
        </div>
      </div>

      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-4 my-5">
      <div className="bg-gray-100 rounded-md p-5">
          <strong className="my-1">Total New Bookings</strong>
          <p className="my-1">{totalNewConnections}</p>

          <button className="view-details-btn bg-blue-500 text-white px-4 py-2 rounded-md">
            View Details
          </button>
        </div>
        <div className="bg-gray-100 rounded-md p-4">
          <strong className="my-1">Total Confirm Bookings</strong>
          <p className="my-1">{totalNewConnections}</p>

          <button className="view-details-btn bg-green-500 text-white px-4 py-2 rounded-md">
            View Details
          </button>
        </div>
        <div className="bg-gray-100 rounded-md p-4">
          <strong className="my-1">Total Cancelled Bookings</strong>
          <p className="my-1">{totalNewConnections}</p>

          <button className="view-details-btn bg-red-500 text-white px-4 py-2 rounded-md">
            View Details
          </button>
        </div>
        <div className="bg-gray-100 rounded-md p-4">
          <strong className="my-1">Total Assign Bookings</strong>
          <p className="my-1">{totalNewConnections}</p>

          <button className="view-details-btn bg-blue-300 text-white px-4 py-2 rounded-md">
            View Details
          </button>
        </div>
      </div>

      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-4 my-5">
      <div className="bg-gray-100 rounded-md p-4">
          <strong className="my-1">Total Delivered Cylinders</strong>
          <p className="my-1">{totalNewConnections}</p>

          <button className="view-details-btn bg-green-500 text-white px-4 py-2 rounded-md">
            View Details
          </button>
        </div>
        <div className="bg-gray-100 rounded-md p-4">
          <strong className="my-1">Total Staff </strong>
          <p className="my-1">{totalNewConnections}</p>

          <button className="view-details-btn bg-blue-500 text-white px-4 py-2 rounded-md">
            View Details
          </button>
        </div>
        <div className="bg-gray-100 rounded-md p-4">
          <strong className="my-1">Total Reg Users</strong>
          <p className="my-1">{totalUsers}</p>

          <button className="view-details-btn bg-blue-500 text-white px-4 py-2 rounded-md">
          <Link href="/admin/RegUsers">View Details</Link>
          </button>
        </div>
      </div> 
    </div>
  );
};

export default AdminDashboard;
