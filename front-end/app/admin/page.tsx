'use client';
import AdminDashboard from "./AdminDasboard/page";
import AdminSidebar from "@/components/AdminSidebar";


const Customer=()=>{
    return(
        <AdminSidebar>
            <AdminDashboard/>
        </AdminSidebar>
    );
}

export default Customer;