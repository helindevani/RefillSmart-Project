'use client';
import AdminSidebar from "@/components/AdminSidebar";
import React, { useState } from "react";

interface Request {
  id: number;
  date: string;
  type: string; // 'Booking' or 'Connection'
  status: string;
}

const Reports: React.FC = () => {
  const [requests, setRequests] = useState<Request[]>([
    { id: 1, date: "2024-04-01", type: "Booking", status: "Confirmed" },
    { id: 2, date: "2024-04-05", type: "Connection", status: "Approved" },
    { id: 3, date: "2024-04-10", type: "Booking", status: "Cancelled" },
    { id: 4, date: "2024-04-15", type: "Connection", status: "Rejected" },
  ]);

  const handleFilterByDate = (startDate: string, endDate: string) => {
    // Filter requests by date range
    const filteredRequests = requests.filter(request =>
      request.date >= startDate && request.date <= endDate
    );
    // Display filtered requests
    console.log(filteredRequests);
  };

  return (
    <AdminSidebar>
    <div className="bg-white px-6 py-8 sm:px-8">
      <h2 className="text-3xl font-bold text-gray-900 mb-6">Reports</h2>
      <div className="flex items-center mb-4">
        <label htmlFor="startDate" className="mr-4">Start Date:</label>
        <input type="date" id="startDate" className="border border-gray-300 px-3 py-2 rounded-md focus:outline-none focus:ring focus:ring-blue-300" />
        <label htmlFor="endDate" className="ml-8 mr-4">End Date:</label>
        <input type="date" id="endDate" className="border border-gray-300 px-3 py-2 rounded-md focus:outline-none focus:ring focus:ring-blue-300" />
        <button onClick={() => handleFilterByDate("2024-04-01", "2024-04-15")} className="bg-blue-500 text-white py-2 px-4 rounded-md hover:bg-blue-600 focus:outline-none focus:ring focus:ring-blue-300">Filter</button>
      </div>
      <table className="w-full border-collapse border border-gray-300">
        <thead>
          <tr className="bg-gray-200">
            <th className="border border-gray-300 px-4 py-2">ID</th>
            <th className="border border-gray-300 px-4 py-2">Date</th>
            <th className="border border-gray-300 px-4 py-2">Type</th>
            <th className="border border-gray-300 px-4 py-2">Status</th>
          </tr>
        </thead>
        <tbody>
          {requests.map(request => (
            <tr key={request.id}>
              <td className="border border-gray-300 px-4 py-2">{request.id}</td>
              <td className="border border-gray-300 px-4 py-2">{request.date}</td>
              <td className="border border-gray-300 px-4 py-2">{request.type}</td>
              <td className="border border-gray-300 px-4 py-2">{request.status}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
    </AdminSidebar>
  );
};

export default Reports;
