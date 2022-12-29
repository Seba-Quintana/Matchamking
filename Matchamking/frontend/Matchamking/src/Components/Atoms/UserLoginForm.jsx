import React from 'react'
import StyledBox from './BoxStyle'
import styled from 'styled-components'

const StyledInput = styled.input`
    all: unset;
    text-align: left;
    align-self: center;
    margin-left: 1rem;
`
const StyledUserLoginForm = styled(StyledBox)`
    margin-top: 1rem;
    justify-content: flex-start;
`
const UserLoginForm = ({text, type}) => {
  return (
    <StyledUserLoginForm>
        <StyledInput type={type} placeholder={text}
        ></StyledInput>
    </StyledUserLoginForm>
  )
}

export default UserLoginForm