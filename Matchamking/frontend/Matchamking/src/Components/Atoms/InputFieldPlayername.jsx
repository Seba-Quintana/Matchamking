import React from 'react'
import StyledBox from './BoxStyle'
import styled from 'styled-components'
import { useState } from 'react'

const StyledInput = styled.input`
    all: unset;
    text-align: left;
    align-self: center;
    margin-left: 1rem;
`
const StyledSearchBox = styled(StyledBox)`
    margin-top: 1rem;
    justify-content: flex-start;
`
const InputFieldPlayername = ({text, setPlayername}) => {
  return (
    <StyledSearchBox>
        <StyledInput type='text' placeholder={text} onChange={ 
          (ev) => {setPlayername(ev.target.value)}}
        ></StyledInput>
    </StyledSearchBox>
  )
}

export default InputFieldPlayername