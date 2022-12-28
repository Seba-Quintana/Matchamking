import React from 'react'
import BackArrow from '../Components/Atoms/BackArrow'
import AdminLogin from '../Components/Organisms/AdminLogin'

const Admin = () => {
  return (
    <>
          <BackArrow navigate={'/'}></BackArrow>
          <AdminLogin></AdminLogin>
    </>
  )
}

export default Admin