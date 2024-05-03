'use client';
import AdminSidebar from "@/components/AdminSidebar";
import React, { useState, useEffect } from "react";

interface user{
  id : string
}

interface ConnectionRequest {
  connectionNo: number;
  name: string;
  email: string;
  status: string;
  remarks: string;
  user : user
}

const Connection: React.FC = () => {
  const [connectionRequests, setConnectionRequests] = useState<ConnectionRequest[]>([]);
  const [remark,setRemark]=useState<string>();  

  useEffect(() => {
    fetch('http://localhost:5057/api/AdminRequests/NewConnection')
      .then(response => {
        if (!response.ok) {
          throw new Error('Failed to fetch data');
        }
        return response.json();
      })
      .then(data => {
        console.log(data)
        setConnectionRequests(data);
      })
      .catch(error => {
        console.error('Error fetching data:', error);
      });
  }, []);

  const handleChangeStatus = (id: string, newStatus: string):any => {
    fetch(`http://localhost:5057/api/Admin/NewConnection/${id}?remark=${remark}&status=${newStatus}`, {
      method: 'PUT',
    })
    .then(response => {
      if (!response.ok) {
        throw new Error('Failed to update status');
      }
    })
    .catch(error => {
      console.error('Error updating status:', error);
    });
  };

  return (
    <AdminSidebar>
      <div className="bg-white px-6 py-8 sm:px-8">
        <h2 className="text-3xl font-bold text-gray-900 mb-6">Connection Requests</h2>
        <table className="w-full border-collapse border border-gray-300">
          <thead>
            <tr className="bg-gray-200">
              <th className="border border-gray-300 px-4 py-2">Connection No</th>
              <th className="border border-gray-300 px-4 py-2">Name</th>
              <th className="border border-gray-300 px-4 py-2">Email</th>
              <th className="border border-gray-300 px-4 py-2">Status</th>
              <th className="border border-gray-300 px-4 py-2">Remarks</th>
              <th className="border border-gray-300 px-4 py-2">Actions</th>
            </tr>
          </thead>
          <tbody>
            {connectionRequests.map(request => (
              <tr key={request.connectionNo}>
                <td className="border border-gray-300 px-4 py-2">{request.connectionNo}</td>
                <td className="border border-gray-300 px-4 py-2">{request.name}</td>
                <td className="border border-gray-300 px-4 py-2">{request.email}</td>
                <td className="border border-gray-300 px-4 py-2">{request.status}</td>
                <td className="border border-gray-300 px-4 py-2">{request.remarks}</td>
                <td className="border border-gray-300 px-4 py-2">
                {request.status === "Pending" && (
                    <>
                      <button onClick={() => handleChangeStatus(request.user.id, "Approved")} className="bg-green-500 text-white py-1 px-2 rounded-md hover:bg-green-600 focus:outline-none focus:ring focus:ring-green-300">
                        Approve
                      </button>
                      <button onClick={() => handleChangeStatus(request.user.id, "Rejected")} className="bg-red-500 text-white py-1 px-2 rounded-md hover:bg-red-600 focus:outline-none focus:ring focus:ring-red-300 ml-2">
                        Reject
                      </button>
                      <input
                        type="text"
                        placeholder="Add remarks"
                        className="ml-2 border border-gray-300 rounded-md px-2 py-1 focus:outline-none focus:ring focus:ring-blue-300"
                        value={remark}
                        onChange={(e) => setRemark(e.target.value)}
                      />
                    </>
                  )}
                  {request.status !== "Pending" && (
                    <span className="text-green-500">Completed</span>
                  )}
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </AdminSidebar>
  );
};

export default Connection;
