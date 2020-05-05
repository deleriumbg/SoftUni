<?php

/* issue/delete.html.twig */
class __TwigTemplate_727ca78d491663cecb72a4216fdfbea8d237f7d4d4bf2731727a3c62ed8ccce4 extends Twig_Template
{
    private $source;

    public function __construct(Twig_Environment $env)
    {
        parent::__construct($env);

        $this->source = $this->getSourceContext();

        // line 1
        $this->parent = $this->loadTemplate("base.html.twig", "issue/delete.html.twig", 1);
        $this->blocks = array(
            'main' => array($this, 'block_main'),
        );
    }

    protected function doGetParent(array $context)
    {
        return "base.html.twig";
    }

    protected function doDisplay(array $context, array $blocks = array())
    {
        $__internal_085b0142806202599c7fe3b329164a92397d8978207a37e79d70b8c52599e33e = $this->extensions["Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension"];
        $__internal_085b0142806202599c7fe3b329164a92397d8978207a37e79d70b8c52599e33e->enter($__internal_085b0142806202599c7fe3b329164a92397d8978207a37e79d70b8c52599e33e_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "issue/delete.html.twig"));

        $__internal_319393461309892924ff6e74d6d6e64287df64b63545b994e100d4ab223aed02 = $this->extensions["Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension"];
        $__internal_319393461309892924ff6e74d6d6e64287df64b63545b994e100d4ab223aed02->enter($__internal_319393461309892924ff6e74d6d6e64287df64b63545b994e100d4ab223aed02_prof = new Twig_Profiler_Profile($this->getTemplateName(), "template", "issue/delete.html.twig"));

        $this->parent->display($context, array_merge($this->blocks, $blocks));
        
        $__internal_085b0142806202599c7fe3b329164a92397d8978207a37e79d70b8c52599e33e->leave($__internal_085b0142806202599c7fe3b329164a92397d8978207a37e79d70b8c52599e33e_prof);

        
        $__internal_319393461309892924ff6e74d6d6e64287df64b63545b994e100d4ab223aed02->leave($__internal_319393461309892924ff6e74d6d6e64287df64b63545b994e100d4ab223aed02_prof);

    }

    // line 3
    public function block_main($context, array $blocks = array())
    {
        $__internal_085b0142806202599c7fe3b329164a92397d8978207a37e79d70b8c52599e33e = $this->extensions["Symfony\\Bundle\\WebProfilerBundle\\Twig\\WebProfilerExtension"];
        $__internal_085b0142806202599c7fe3b329164a92397d8978207a37e79d70b8c52599e33e->enter($__internal_085b0142806202599c7fe3b329164a92397d8978207a37e79d70b8c52599e33e_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "main"));

        $__internal_319393461309892924ff6e74d6d6e64287df64b63545b994e100d4ab223aed02 = $this->extensions["Symfony\\Bridge\\Twig\\Extension\\ProfilerExtension"];
        $__internal_319393461309892924ff6e74d6d6e64287df64b63545b994e100d4ab223aed02->enter($__internal_319393461309892924ff6e74d6d6e64287df64b63545b994e100d4ab223aed02_prof = new Twig_Profiler_Profile($this->getTemplateName(), "block", "main"));

        // line 4
        echo "    <div class=\"wrapper\">
        <form class=\"issue-create\" method=\"post\">
            <div class=\"create-header\">
                Close Issue
            </div>
            <div class=\"create-title\">
                <div class=\"create-title-label\">Title</div>
                <input class=\"create-title-content\" name=\"issue[title]\" value=\"";
        // line 11
        echo twig_escape_filter($this->env, twig_get_attribute($this->env, $this->source, (isset($context["issue"]) || array_key_exists("issue", $context) ? $context["issue"] : (function () { throw new Twig_Error_Runtime('Variable "issue" does not exist.', 11, $this->source); })()), "title", array()), "html", null, true);
        echo "\" disabled=\"disabled\"  readonly/>
            </div>
            <div class=\"create-issueitem\">
                <div class=\"create-issueitem-label\">Content</div>
                <textarea rows=\"3\" class=\"create-issueitem-content\" name=\"issue[content]\" disabled=\"disabled\" readonly
                >";
        // line 16
        echo twig_escape_filter($this->env, twig_get_attribute($this->env, $this->source, (isset($context["issue"]) || array_key_exists("issue", $context) ? $context["issue"] : (function () { throw new Twig_Error_Runtime('Variable "issue" does not exist.', 16, $this->source); })()), "content", array()), "html", null, true);
        echo "</textarea>
            </div>
            <div class=\"create-issueitem\">
                <div class=\"create-issueitem-label\">Priority</div>
                <input type=\"number\" min=\"0\" class=\"create-issueitem-content\" name=\"issue[priority]\" disabled=\"disabled\"
                value=\"";
        // line 21
        echo twig_escape_filter($this->env, twig_get_attribute($this->env, $this->source, (isset($context["issue"]) || array_key_exists("issue", $context) ? $context["issue"] : (function () { throw new Twig_Error_Runtime('Variable "issue" does not exist.', 21, $this->source); })()), "priority", array()), "html", null, true);
        echo "\"
                readonly/>
            </div>
            <div class=\"create-button-holder\">
                <button type=\"submit\" class=\"button\">Close Issue</button>
                <a type=\"button\" href=\"/\" class=\"button\">Back</a>
            </div>
            ";
        // line 28
        echo $this->env->getRuntime('Symfony\Component\Form\FormRenderer')->searchAndRenderBlock(twig_get_attribute($this->env, $this->source, (isset($context["form"]) || array_key_exists("form", $context) ? $context["form"] : (function () { throw new Twig_Error_Runtime('Variable "form" does not exist.', 28, $this->source); })()), "_token", array()), 'row');
        echo "
        </form>
    </div>
";
        
        $__internal_319393461309892924ff6e74d6d6e64287df64b63545b994e100d4ab223aed02->leave($__internal_319393461309892924ff6e74d6d6e64287df64b63545b994e100d4ab223aed02_prof);

        
        $__internal_085b0142806202599c7fe3b329164a92397d8978207a37e79d70b8c52599e33e->leave($__internal_085b0142806202599c7fe3b329164a92397d8978207a37e79d70b8c52599e33e_prof);

    }

    public function getTemplateName()
    {
        return "issue/delete.html.twig";
    }

    public function isTraitable()
    {
        return false;
    }

    public function getDebugInfo()
    {
        return array (  88 => 28,  78 => 21,  70 => 16,  62 => 11,  53 => 4,  44 => 3,  15 => 1,);
    }

    public function getSourceContext()
    {
        return new Twig_Source("{% extends \"base.html.twig\" %}

{% block main %}
    <div class=\"wrapper\">
        <form class=\"issue-create\" method=\"post\">
            <div class=\"create-header\">
                Close Issue
            </div>
            <div class=\"create-title\">
                <div class=\"create-title-label\">Title</div>
                <input class=\"create-title-content\" name=\"issue[title]\" value=\"{{ issue.title }}\" disabled=\"disabled\"  readonly/>
            </div>
            <div class=\"create-issueitem\">
                <div class=\"create-issueitem-label\">Content</div>
                <textarea rows=\"3\" class=\"create-issueitem-content\" name=\"issue[content]\" disabled=\"disabled\" readonly
                >{{ issue.content }}</textarea>
            </div>
            <div class=\"create-issueitem\">
                <div class=\"create-issueitem-label\">Priority</div>
                <input type=\"number\" min=\"0\" class=\"create-issueitem-content\" name=\"issue[priority]\" disabled=\"disabled\"
                value=\"{{ issue.priority }}\"
                readonly/>
            </div>
            <div class=\"create-button-holder\">
                <button type=\"submit\" class=\"button\">Close Issue</button>
                <a type=\"button\" href=\"/\" class=\"button\">Back</a>
            </div>
            {{ form_row(form._token) }}
        </form>
    </div>
{% endblock %}", "issue/delete.html.twig", "C:\\SoftUni\\Software_Technologies\\18_Exam\\PHP\\app\\Resources\\views\\issue\\delete.html.twig");
    }
}
