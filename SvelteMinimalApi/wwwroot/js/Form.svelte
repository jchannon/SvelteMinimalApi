<svelte:options tag="svelte-form"/>
<script>
    export let tokenfieldname;
    export let tokenvalue;
</script>

<h1>Create a free account</h1>
<form action="/" method="post">
    <input value="{tokenvalue}" name="{tokenfieldname}" type="hidden" />
    <input name="username" placeholder="Username"/>
    <input name="password" placeholder="Password"/>
    <input type="submit" value="create"/>
</form>