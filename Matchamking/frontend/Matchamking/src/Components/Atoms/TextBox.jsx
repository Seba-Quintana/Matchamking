import React from 'react'
import styled from 'styled-components'

const StyledTextBox = styled.div`
    width: 90%;
    height: auto;
    font-family: 'Inter', sans-serif;
    font-size: 15px;
    margin-top: 1rem;
    text-align: justify;
    color: white;
    max-width: 500px;
`

const TextBox = (
    {text}
) => {
  return (
    <StyledTextBox>
        {text}
    </StyledTextBox>
  )
}

export default TextBox