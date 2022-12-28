import React from 'react'
import AdminLoginBtn from '../Atoms/AdminLoginBtn'
import HeaderText from '../Atoms/HeaderText'
import TextBox from '../Atoms/TextBox'
import UserLoginForm from '../Atoms/UserLoginForm'

const AdminLogin = () => {
  return (
    <>
        <HeaderText text='Panel de admin'>
        </HeaderText>
        <UserLoginForm type='text' text='Nombre de usuario'>
        </UserLoginForm>
        <UserLoginForm type='password' text='Contraseña'>
        </UserLoginForm>
        <AdminLoginBtn></AdminLoginBtn>
        <TextBox text='
        Panel de creación de partidos y modificación de jugadores.
        Uso exclusivo del admin.
        '></TextBox>

    </>
  )
}

export default AdminLogin