'use client';
import React, { useState } from "react";
import Sidebar from "@/components/Sidebar";
import ContactUs from "@/components/ContactUs";
import Cookies from "js-cookie";
import UserSummaryReport from "../NewConnectionSummary/page";

interface FormData {
  Name: string;
  Email: string;
  Dob: string;
  MaritalStatus: number;
  MobileNo: string;
  Gender: string;
  Address: string;
  AddressProof: File | null;
  RationCardNo: string;
  Nationality: number;
  Related: number;
  FirstName: string;
  LastName: string;
  RelatedAddress: string;
  City: string;
  PinCode: string;
}

const NewConnectionForm: React.FC = () => {
  const [showForm, setShowForm] = useState(true);
  const [formData, setFormData] = useState({
    Name: "",
    Email: "",
    Dob: "",
    MaritalStatus: 0,
    MobileNo: "",
    Gender: "",
    Address: "",
    AddressProof: null,
    RationCardNo: "",
    Nationality: 0,
    Related: 0,
    FirstName: "",     
    LastName: "",
    RelatedAddress: "",
    City: "",
    PinCode: "",
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement>) => {
    const { name, value } = e.target;
    console.log(name,value)
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, files } = e.target;
    if (files && files.length > 0) {
      setFormData({
        ...formData,
        [name]: files[0],
      });
    }
  };

  const handleRadioChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: parseInt(value),
    });
  };

  const submitAdminRequest = async () => {
    const token = Cookies.get('token');

    if (!token) {
      console.error('JWT token not found');
      return;
    }

    const decodedToken = parseJwt(token);
    const userId = decodedToken ? decodedToken.sub : null;

    if (!userId) {
      console.error('User ID not found in token');
      return;
    }

    const data = {
      Description: 'New connection request submitted',
      RequestTypeName: 'NewConnection',
      Id: userId
    };

    try {
      const responsedata = await fetch('http://localhost:5057/api/AdminRequests', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${token}`
        },
        body: JSON.stringify(data),
      });

      if (responsedata.ok) {
        console.log('Admin request submitted successfully');
      } else {
        console.error('Failed to submit admin request');
      }
    } catch (error) {
      console.error('Error submitting admin request:', error);
    }
  };

  const submitHandler = async (event: React.FormEvent<HTMLFormElement>): Promise<void> => {
    event.preventDefault();

    try {   
      const formDataToSend = new FormData();
      for (const [key, value] of Object.entries(formData)) {
        if ((value as any)  instanceof File) {
          formDataToSend.append(key, value as any);
        } else if (value !== null && typeof value !== 'undefined') {
          formDataToSend.append(key, String(value));
        }
      }

      const response = await fetch("http://localhost:5057/api/NewConnectionForms", {
        method: "POST",
        body: formDataToSend,
        headers :{
          Authorization: `Bearer ${Cookies.get('token')}`
        }
      });
      
      if (!response.ok) {
        throw new Error("Failed to submit form");
      }

      console.log("Form submitted successfully");

      setShowForm(false);

    } catch (error: any) {
      console.error("Error submitting form:", error.message);
    }
  };


 

  const parseJwt = (token: string) => {
    try {
      return JSON.parse(atob(token.split('.')[1]));
    } catch (e) {
      return null;
    }
  };

  return (
    <>
      {showForm && (
        <Sidebar>
          <div className="isolate bg-white px-6 py-24 sm:py-32 lg:px-8 relative">
            <div
              className="absolute inset-x-0 top-[-10rem] -z-10 transform-gpu overflow-hidden blur-3xl sm:top-[-20rem]"
              aria-hidden="true"
            >
              <div
                className="relative left-1/2 -z-10 aspect-[1155/678] w-[36.125rem] max-w-none -translate-x-1/2 rotate-[30deg] bg-gradient-to-r from-[#ff80b5] to-[#9089fc] opacity-30 sm:left-[calc(50%-40rem)] sm:w-[72.1875rem]"
                style={{
                  clipPath:
                    "polygon(74.1% 44.1%, 100% 61.6%, 97.5% 26.9%, 85.5% 0.1%, 80.7% 2%, 72.5% 32.5%, 60.2% 62.4%, 52.4% 68.1%, 47.5% 58.3%, 45.2% 34.5%, 27.5% 76.7%, 0.1% 64.9%, 17.9% 100%, 27.6% 76.8%, 76.1% 97.7%, 74.1% 44.1%)",
                }}
              ></div>
            </div>
            <div className="mx-auto max-w-2xl text-center">
              <h2 className="text-3xl font-bold tracking-tight text-gray-900 sm:text-4xl">
                New Connection Form
              </h2>
            </div>
            <form
              onSubmit={submitHandler}
              className="mx-auto mt-16 max-w-xl sm:mt-20"
            >
              <div className="grid grid-cols-1 gap-x-8 gap-y-6 sm:grid-cols-2">
                <div>
                  <label
                    htmlFor="Name"
                    className="block text-sm font-semibold leading-6 text-gray-900"
                  >
                    Name
                  </label>
                  <div className="mt-2.5">
                    <input
                      type="text"
                      name="Name"
                      id="Name"
                      autoComplete="given-name"
                      onChange={handleChange}
                      className="block w-full rounded-md border-0 px-3.5 py-2 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder-text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    />
                  </div>
                </div>
                <div>
                  <label
                    htmlFor="Email"
                    className="block text-sm font-semibold leading-6 text-gray-900"
                  >
                    Email
                  </label>
                  <div className="mt-2.5">
                    <input
                      type="email"
                      name="Email"
                      id="Email"
                      onChange={handleChange}
                      className="block w-full rounded-md border-0 px-3.5 py-2 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder-text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    />
                  </div>
                </div>
                <div>
                  <label
                    htmlFor="Dob"
                    className="block text-sm font-semibold leading-6 text-gray-900"
                  >
                    Date Of Birth
                  </label>
                  <div className="mt-2.5">
                    <input
                      type="date"
                      name="Dob"
                      id="Dob"
                      onChange={handleChange}
                      className="block w-full rounded-md border-0 px-3.5 py-2 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder-text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    />
                  </div>
                </div>
                <div>
                  <label
                    htmlFor="MaritalStatus"
                    className="block text-sm font-semibold leading-6 text-gray-900"
                  >
                    Maritial Status
                  </label>
                  <div className="mt-2.5">
                    <select
                      id="MaritalStatus"
                      name="MaritalStatus"
                      onChange={handleChange}
                      className="block w-full rounded-md border-0 px-3.5 py-2 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder-text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    >
                      <option value={0}>Single</option>
                      <option value={1}>Married</option>
                      <option value={2}>Divorced</option>
                      <option value={3}>Widowed</option>
                    </select>
                    <svg
                      className="pointer-events-none absolute right-3 top-0 h-full w-5 text-gray-400"
                      viewBox="0 0 20 20"
                      fill="currentColor"
                      aria-hidden="true"
                    >
                      <path
                        fillRule="evenodd"
                        d="M5.23 7.21a.75.75 0 011.06.02L10 11.168l3.71-3.938a.75.75 0 111.08 1.04l-4.25 4.5a.75.75 0 01-1.08 0l-4.25-4.5a.75.75 0 01.02-1.06z"
                        clipRule="evenodd"
                      />
                    </svg>
                  </div>
                </div>
                <div>
                  <label
                    htmlFor="MobileNo"
                    className="block text-sm font-semibold leading-6 text-gray-900"
                  >
                    Phone number
                  </label>
                  <div className="relative mt-2.5">
                    <div className="relative">
                      <div className="absolute inset-y-0 start-0 top-0 flex items-center ps-3.5 pointer-events-none">
                        <svg
                          className="w-4 h-4 text-gray-500 dark:text-gray-400"
                          aria-hidden="true"
                          xmlns="http://www.w3.org/2000/svg"
                          fill="currentColor"
                          viewBox="0 0 19 18"
                        >
                          <path d="M18 13.446a3.02 3.02 0 0 0-.946-1.985l-1.4-1.4a3.054 3.054 0 0 0-4.218 0l-.7.7a.983.983 0 0 1-1.39 0l-2.1-2.1a.983.983 0 0 1 0-1.389l.7-.7a2.98 2.98 0 0 0 0-4.217l-1.4-1.4a2.824 2.824 0 0 0-4.218 0c-3.619 3.619-3 8.229 1.752 12.979C6.785 16.639 9.45 18 11.912 18a7.175 7.175 0 0 0 5.139-2.325A2.9 2.9 0 0 0 18 13.446Z" />
                        </svg>
                      </div>
                      <input
                        type="tel"
                        id="MobileNo"
                        name="MobileNo"
                        aria-describedby="helper-text-explanation"
                        className="block w-full rounded-md border-0 px-3.5 py-2 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder-text-gray-400 focus:ring-2 focus:ring-inset  focus:ring-indigo-600 sm:text-sm sm:leading-6 text-sm ps-10 p-2.5"
                        pattern="[0-9]{10}"
                        placeholder="123-456-7890"
                        onChange={handleChange}
                        required
                      />
                    </div>
                  </div>
                </div>
                <div>
                  <label
                    htmlFor="Gender"
                    className="block text-sm font-semibold leading-6 text-gray-900"
                  >
                    Gender
                  </label>
                  <div className="mt-2.5">
                    <select
                      id="Gender"
                      name="Gender"
                      onChange={handleChange}
                      className="block w-full rounded-md border-0 px-3.5 py-2 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder-text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    >
                      <option value="Male">Male</option>
                      <option value="Female">Female</option>
                      <option value="Other">Other</option>
                    </select>
                    <svg
                      className="pointer-events-none absolute right-3 top-0 h-full w-5 text-gray-400"
                      viewBox="0 0 20 20"
                      fill="currentColor"
                      aria-hidden="true"
                    >
                      <path
                        fillRule="evenodd"
                        d="M5.23 7.21a.75.75 0 011.06.02L10 11.168l3.71-3.938a.75.75 0 111.08 1.04l-4.25 4.5a.75.75 0 01-1.08 0l-4.25-4.5a.75.75 0 01.02-1.06z"
                        clipRule="evenodd"
                      />
                    </svg>
                  </div>
                </div>
                <div className="sm:col-span-2">
                  <label
                    htmlFor="Address"
                    className="block text-sm font-semibold leading-6 text-gray-900"
                  >
                    Address
                  </label>
                  <div className="mt-2.5">
                    <textarea
                      name="Address"
                      id="Address"
                      rows={4}
                      onChange={handleChange}
                      className="block w-full rounded-md border-0 px-3.5 py-2 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder-text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    ></textarea>
                  </div>
                </div>

                <div className="sm:col-span-2">
                  <label
                    htmlFor="AddressProof"
                    className="block text-sm font-semibold leading-6 text-gray-900"
                  >
                    Address Proof
                  </label>
                  <div className="relative mt-2.5">
                    <input
                      type="file"
                      name="AddressProof"
                      id="AddressProof"
                      onChange={handleFileChange}
                      className="block w-full rounded-md border-0 px-3.5 py-2 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder-text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    />
                  </div>
                </div>

                <div>
                  <label
                    htmlFor="RationCardNo"
                    className="block text-sm font-semibold leading-6 text-gray-900"
                  >
                    Ration Card Number
                  </label>
                  <div className="relative mt-2.5">
                    <input
                      type="text"
                      name="RationCardNo"
                      id="RationCardNo"
                      onChange={handleChange}
                      maxLength={14}
                      minLength={14}
                      className="block w-full rounded-md border-0 px-3.5 py-2 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder-text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    />
                  </div>
                </div>

                <div>
                  <label
                    htmlFor="Nationality"
                    className="block text-sm font-semibold leading-6 text-gray-900"
                  >
                    Nationality
                  </label>
                  <div className="mt-2.5">
                    <select
                      id="Nationality"
                      name="Nationality"
                      onChange={handleChange}
                      className="block w-full rounded-md border-0 px-3.5 py-2 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder-text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    >
                      <option value={0}>Indian</option>
                      <option value={1}>Non Indian</option>
                    </select>
                    <svg
                      className="pointer-events-none absolute right-3 top-0 h-full w-5 text-gray-400"
                      viewBox="0 0 20 20"
                      fill="currentColor"
                      aria-hidden="true"
                    >
                      <path
                        fillRule="evenodd"
                        d="M5.23 7.21a.75.75 0 011.06.02L10 11.168l3.71-3.938a.75.75 0 111.08 1.04l-4.25 4.5a.75.75 0 01-1.08 0l-4.25-4.5a.75.75 0 01.02-1.06z"
                        clipRule="evenodd"
                      />
                    </svg>
                  </div>
                </div>

                <div className="sm:col-span-2">
                  <label
                    htmlFor="Related"
                    className="block text-xl font-semibold leading-6 text-gray-900"
                  >
                    Father / Spouse Details
                  </label>
                  <div className="flex items-center">
                    <input
                      type="radio"
                      name="Related"
                      value={0}
                      id="Father"
                      onChange={handleRadioChange}
                      className="mx-2"
                    />
                    <label htmlFor="Father" className="mr-2">
                      Father
                    </label>
                    <input
                      type="radio"
                      name="Related"
                      value={1}
                      id="Spouse"
                      onChange={handleRadioChange}
                      className="mx-2"
                    />
                    <label htmlFor="Spouse">Spouse</label>
                  </div>
                </div>

                <div>
                  <label
                    htmlFor="FirstName"
                    className="block text-sm font-semibold leading-6 text-gray-900"
                  >
                    First Name
                  </label>
                  <div className="mt-2.5">
                    <input
                      type="text"
                      name="FirstName"
                      id="FirstName"
                      onChange={handleChange}
                      autoComplete="given-name"
                      className="block w-full rounded-md border-0 px-3.5 py-2 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder-text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    />
                  </div>
                </div>
                <div>
                  <label
                    htmlFor="LastName"
                    className="block text-sm font-semibold leading-6 text-gray-900"
                  >
                    Last Name
                  </label>
                  <div className="mt-2.5">
                    <input
                      type="text"
                      name="LastName"
                      id="LastName"
                      onChange={handleChange}
                      autoComplete="given-name"
                      className="block w-full rounded-md border-0 px-3.5 py-2 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder-text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    />
                  </div>
                </div>

                <div className="sm:col-span-2">
                  <label
                    htmlFor="RelatedAddress"
                    className="block text-sm font-semibold leading-6 text-gray-900"
                  >
                    Address
                  </label>
                  <div className="mt-2.5">
                    <textarea
                      name="RelatedAddress"
                      id="RelatedAddress"
                      rows={4}
                      onChange={handleChange}
                      className="block w-full rounded-md border-0 px-3.5 py-2 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder-text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    ></textarea>
                  </div>
                </div>

                <div>
                  <label
                    htmlFor="City"
                    className="block text-sm font-semibold leading-6 text-gray-900"
                  >
                    City
                  </label>
                  <div className="mt-2.5">
                    <input
                      type="text"
                      name="City"
                      id="City"
                      onChange={handleChange}
                      autoComplete="given-name"
                      className="block w-full rounded-md border-0 px-3.5 py-2 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder-text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    />
                  </div>
                </div>

                <div>
                  <label
                    htmlFor="PinCode"
                    className="block text-sm font-semibold leading-6 text-gray-900"
                  >
                    Pin Code
                  </label>
                  <div className="mt-2.5">
                    <input
                      type="text"
                      name="PinCode"
                      id="PinCode"
                      onChange={handleChange}
                      maxLength={6}
                      minLength={6}
                      className="block w-full rounded-md border-0 px-3.5 py-2 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder-text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    />
                  </div>
                </div>
              </div>
              <div className="mt-10">
                <button
                  type="submit"
                  className="block w-full rounded-md bg-indigo-600 px-3.5 py-2.5 text-center text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
                  onClick={submitAdminRequest}
                >
                  Submit
                </button>
              </div>
            </form>
          </div>
          </Sidebar>
      )}
      {!showForm && (
          <UserSummaryReport />
      )}
      </>
      
  );
};

export default NewConnectionForm;




